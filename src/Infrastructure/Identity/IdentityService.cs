using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SolutionNamePlaceholder.Application.Interfaces;
using SolutionNamePlaceholder.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionNamePlaceholder.Infrastructure.Identity
{
    public class IdentityService(
        UserManager<ContaUsuario> userManager,
        RoleManager<IdentityRole> roleManager
    ) : IAuthService
    {
        public async Task AdicionarRoleAsync(string email, string roleName)
        {
            var user = await userManager.FindByEmailAsync(email) ??
                throw new RecursoNaoEncontradoException(nameof(ContaUsuario), email);
            var role = await roleManager.FindByNameAsync(roleName.ToUpper()) ??
                throw new RecursoNaoEncontradoException(nameof(IdentityRole), roleName);

            await userManager.AddToRoleAsync(user, role.Name!);
        }

        public async Task RetirarRoleAsync(string email, string roleName)
        {
            var user = await userManager.FindByEmailAsync(email) ??
                throw new RecursoNaoEncontradoException(nameof(ContaUsuario), email);
            var role = await roleManager.FindByNameAsync(roleName) ??
                throw new RecursoNaoEncontradoException(nameof(IdentityRole), roleName);

            await userManager.RemoveFromRoleAsync(user, role.Name!);
        }
    }
}
