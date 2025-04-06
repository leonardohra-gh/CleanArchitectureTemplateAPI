using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SolutionNamePlaceholder.Application.Interfaces;
using SolutionNamePlaceholder.Infrastructure.Authorization;
using SolutionNamePlaceholder.Infrastructure.Identity;
using SolutionNamePlaceholder.Infrastructure.Persistance;
using SolutionNamePlaceholder.Infrastructure.Seeders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionNamePlaceholder.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("SolutionNamePlaceholderBD");
            services.AddDbContext<ContextoBD>(
                options => options.UseSqlServer(connectionString)
                //.EnableSensitiveDataLogging()
            );

            services.AddIdentityApiEndpoints<ContaUsuario>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ContextoBD>();

            services
                .AddScoped<ISeeder, RoleSeeder>()
                .AddScoped<ISeeder, UsuarioSeeder>()
                .AddScoped<ExecutorSeed>();

            services
                .AddScoped<IAuthService, IdentityService>()
                .AddScoped<IContextoUsuario, ContextoUsuario>();
        }
    }
}
