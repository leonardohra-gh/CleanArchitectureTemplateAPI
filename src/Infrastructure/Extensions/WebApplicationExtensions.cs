using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
    public static class WebApplicationExtensions
    {
        public static void AddInfrastructure(this WebApplication app)
        {
            MigrarBancoDeDadosSeNecessario(app);

            app.MapGroup("api/identity")
                .WithTags("Identity")
                .MapIdentityApi<ContaUsuario>();

            RodarSeedersSeNecessario(app);

        }

        private static void MigrarBancoDeDadosSeNecessario(WebApplication app)
        {
            using var migrationScope = app.Services.CreateScope();
            var dbContext = migrationScope.ServiceProvider
                .GetRequiredService<ContextoBD>();
            dbContext.Database.Migrate();
        }

        private static void RodarSeedersSeNecessario(WebApplication app)
        {
            using var seedScope = app.Services.CreateScope();
            seedScope.ServiceProvider
                .GetRequiredService<ExecutorSeed>()
                .ExecutarSeeders()
                .GetAwaiter()
                .GetResult();
        }
    }
}
