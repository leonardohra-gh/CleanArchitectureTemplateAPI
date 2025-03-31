using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SolutionNamePlaceholder.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionNamePlaceholder.Infrastructure.Seeders
{
    public class RoleSeeder(RoleManager<IdentityRole> roleManager) : ISeeder
    {
        public int Ordem => 1;

        public async Task Seed()
        {
            if (await roleManager.Roles.AnyAsync()) return;

            var roles = RetornarRoles();

            foreach (var role in roles) await roleManager.CreateAsync(role);
        }

        private static List<IdentityRole> RetornarRoles()
        {
            List<IdentityRole> roles = [
                new(RolesUsuario.Admin) {NormalizedName = RolesUsuario.Admin.ToUpper()},
                new(RolesUsuario.Usuario) {NormalizedName = RolesUsuario.Usuario.ToUpper()},
            ];

            return roles;
        }
    }
}
