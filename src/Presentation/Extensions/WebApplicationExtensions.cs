using Serilog;
using SolutionNamePlaceholder.Infrastructure.Identity;
using SolutionNamePlaceholder.Presentation.Middlewares;

namespace SolutionNamePlaceholder.Presentation.Extensions
{
    public static class WebApplicationExtensions
    {
        public static void AddPresentation(this WebApplication app)
        {
            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseSerilogRequestLogging();

            // Defina se você quer usar o swagger UI ou não.
            var shouldShowSwagger = true; // app.Environment.IsDevelopment()

            if (shouldShowSwagger)
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
                    c.DocumentTitle = $"{app.Environment.ApplicationName} - Swagger";
                    c.DisplayRequestDuration();
                    c.EnableDeepLinking();
                    c.DefaultModelsExpandDepth(-1);
                });
            }

            app.UseHttpsRedirection();

            app.MapGroup("api/identity")
                .WithTags("Identity")
                .MapIdentityApi<ContaUsuario>();

            app.UseAuthorization();

            app.MapControllers();
        }
    }
}
