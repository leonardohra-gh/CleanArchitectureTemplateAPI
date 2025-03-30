using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionNamePlaceholder.Application.ContaUsuarios.Commands.RetirarRoleUsuario
{
    public class RetirarRoleUsuarioCommand : IRequest
    {
        public string EmailUsuario { get; set; } = default!;
        public string NomeRole { get; set; } = default!;
    }
}
