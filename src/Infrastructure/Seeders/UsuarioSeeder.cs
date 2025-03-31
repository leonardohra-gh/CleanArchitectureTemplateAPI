using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SolutionNamePlaceholder.Domain.Constants;
using SolutionNamePlaceholder.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionNamePlaceholder.Infrastructure.Seeders
{
    public class UsuarioSeeder(UserManager<ContaUsuario> userManager) : ISeeder
    {
        public int Ordem => 2;

        public async Task Seed()
        {
            if (await userManager.Users.AnyAsync()) return;

            var usuarios = RetornarUsuarios();

            foreach (var usuario in usuarios)
            {
                await userManager.CreateAsync(usuario, "Password123!");
                await userManager.AddToRoleAsync(usuario, RolesUsuario.Admin);
            }
        }

        private static List<ContaUsuario> RetornarUsuarios()
        {
            List<ContaUsuario> usuarios = [
                new() { UserName = "admin", Email = "admin@test.com"},
            ];

            return usuarios;
        }
    }
}
