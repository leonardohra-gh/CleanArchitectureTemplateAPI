using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionNamePlaceholder.Application.Interfaces
{
    public interface IAuthService
    {
        Task AdicionarRoleAsync(string email, string roleName);
        Task RetirarRoleAsync(string email, string roleName);
    }
}
