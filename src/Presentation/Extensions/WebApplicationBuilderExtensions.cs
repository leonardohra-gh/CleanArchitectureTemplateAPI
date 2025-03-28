using Microsoft.OpenApi.Models;
using Presentation.Middlewares;
using Serilog;

namespace Presentation.Extensions
{
    public static class WebApplicationBuilderExtensions
    {
        public static void AddPresentation(this WebApplicationBuilder builder)
        {
            builder.Services.AddAuthentication();
            builder.Services.AddControllers();

            ConfigureSwagger(builder);

            builder.Services.AddScoped<ErrorHandlingMiddleware>();

            builder.Host.UseSerilog((context, configuration) =>
                configuration.ReadFrom.Configuration(context.Configuration)
            );
        }
        private static void ConfigureSwagger(WebApplicationBuilder builder)
        {
            var securityDef = "bearerAuth";

            builder.Services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition(securityDef, new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference {Type = ReferenceType.SecurityScheme, Id = securityDef}
                        },
                        []
                    }
                });
            });

            builder.Services.AddEndpointsApiExplorer();
        }
    }
}
