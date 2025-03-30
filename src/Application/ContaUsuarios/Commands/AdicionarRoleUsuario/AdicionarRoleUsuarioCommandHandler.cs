using MediatR;
using Microsoft.Extensions.Logging;
using SolutionNamePlaceholder.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionNamePlaceholder.Application.ContaUsuarios.Commands.AdicionarRoleUsuario
{
    public class AdicionarRoleUsuarioCommandHandler(
        ILogger<AdicionarRoleUsuarioCommandHandler> logger,
        IAuthService servico
    ) : IRequestHandler<AdicionarRoleUsuarioCommand>
    {
        public async Task Handle(AdicionarRoleUsuarioCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Adicionando role ao usuário: {@Request}", request);
            await servico.AdicionarRoleAsync(request.EmailUsuario, request.NomeRole);
        }
    }
}
