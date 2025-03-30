using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolutionNamePlaceholder.Application.ContaUsuarios
{
    public record ContaUsuarioAtual(string Id, string Email, IEnumerable<string> Roles)
    {
        public bool PossuiRole(string role) => Roles.Contains(role);
    }
}