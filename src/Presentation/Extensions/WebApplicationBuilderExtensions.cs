using Microsoft.OpenApi.Models;
using SolutionNamePlaceholder.Presentation.Middlewares;
using Serilog;
using System.Reflection;
using SolutionNamePlaceholder.Application.Interfaces;
using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using SolutionNamePlaceholder.Application.Services.Versao;

namespace SolutionNamePlaceholder.Presentation.Extensions
{
    public static class WebApplicationBuilderExtensions
    {
        public static void AddPresentation(this WebApplicationBuilder builder)
        {
            builder.Services.AddAuthentication();
            builder.Services.AddControllers();

            ConfigureVersioning(builder);
            ConfigureSwagger(builder);

            builder.Services.AddScoped<ErrorHandlingMiddleware>();

            builder.Host.UseSerilog((context, configuration) =>
                configuration.ReadFrom.Configuration(context.Configuration)
            );
        }

        private static void ConfigureVersioning(WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<IVersionService, VersionService>();
            builder.Services.AddApiVersioning(options => 
            {
                var versionService = builder.Services.BuildServiceProvider().GetRequiredService<IVersionService>();
                options.DefaultApiVersion = new ApiVersion(versionService.Major, versionService.Minor);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
            });
        }

        private static void ConfigureSwagger(WebApplicationBuilder builder)
        {
            var apiVersion = "v1";
            var solutionName = "SolutionNamePlaceholder"; 
            var apiTitle = $"{solutionName} API";

            var securityDef = "bearerAuth";

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(apiVersion, new OpenApiInfo
                {
                    Title = apiTitle,
                    Version = apiVersion,
                    Description = "{INSIRA DESCRIÇÃO AQUI}",
                    Contact = new OpenApiContact
                    {
                        Name = "{INSIRA O NOME AQUI}",
                        Email = "{INSIRA O EMAIL AQUI}",
                        Url = new Uri("https://www.google.com.br")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "{SUA LICENÇA}",
                        Url = new Uri("https://opensource.org/licenses/MIT")
                    }
                });

                c.AddSecurityDefinition(securityDef, new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    Description = "Autorização Bearer para AspNetCore Identity" // Se quiser, remova isso 
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

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            builder.Services.AddEndpointsApiExplorer();
        }
    }
}
