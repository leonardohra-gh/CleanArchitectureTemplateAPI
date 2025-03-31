using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using SolutionNamePlaceholder.Infrastructure.Identity;
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
            app.MapGroup("api/identity")
                .WithTags("Identity")
                .MapIdentityApi<ContaUsuario>();

            app.Services
                .CreateScope().ServiceProvider
                .GetRequiredService<ExecutorSeed>()
                .ExecutarSeeders()
                .GetAwaiter()
                .GetResult();
        }
    }
}
