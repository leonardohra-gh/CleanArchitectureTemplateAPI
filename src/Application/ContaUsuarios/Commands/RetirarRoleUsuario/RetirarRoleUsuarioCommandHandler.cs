using MediatR;
using Microsoft.Extensions.Logging;
using SolutionNamePlaceholder.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionNamePlaceholder.Application.ContaUsuarios.Commands.RetirarRoleUsuario
{
    public class RetirarRoleUsuarioCommandHandler(
        ILogger<RetirarRoleUsuarioCommand> logger,
        IAuthService servico
        ) : IRequestHandler<RetirarRoleUsuarioCommand>
    {
        public async Task Handle(RetirarRoleUsuarioCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Retirando role do usuário: {@Request}", request);
            await servico.RetirarRoleAsync(request.EmailUsuario, request.NomeRole);
        }
    }
}
