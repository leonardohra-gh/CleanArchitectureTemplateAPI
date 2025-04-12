#!/bin/bash

set -eo pipefail

BACKUP_DIR="./backups"
VOLUME_NAME="solutionnameplaceholder_sql-data"
TODAY=$(date +%Y%m%d_%H%M%S)

backup() {
    echo "Começando backup..."
    mkdir -p "$BACKUP_DIR"
    docker run --rm \
        -v "$VOLUME_NAME:/volume" \
        -v "$(pwd)/$BACKUP_DIR:/backup" \
        alpine \
        tar -czf "/backup/backup_$TODAY.tar.gz" -C /volume ./
    echo "Backup criado: $BACKUP_DIR/backup_$TODAY.tar.gz"
    
    # Remover backups mais antigos que 1 semana
    find "$BACKUP_DIR" -name "backup_*.tar.gz" -type f -mtime +7 -delete
}

restore() {
    local backup_file="$1"
    echo "Começando a restaurar o backup de $backup_file..."
    
    if [ ! -f "$backup_file" ]; then
        echo "Backup $backup_file não encontrado!"
        exit 1
    fi

    docker compose down || true
    docker run --rm \
        -v "$VOLUME_NAME:/volume" \
        -v "$(pwd)/$backup_file:/backup.tar.gz" \
        alpine \
        sh -c "rm -rf /volume/* && tar -xzf /backup.tar.gz -C /volume"
    echo "Restauração completa."
}

usage() {
    echo "Uso:"
    echo "  $0               Criar o backup"
    echo "  $0 -r|--restore <file>  Restaurar de um arquivo de backup"
    exit 1
}

while [[ $# -gt 0 ]]; do
    case $1 in
        -r|--restore)
            RESTORE_FILE="$2"
            shift
            shift
            restore "$RESTORE_FILE"
            exit 0
            ;;
        *)
            usage
            ;;
    esac
done

backup