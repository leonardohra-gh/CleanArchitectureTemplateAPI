using SolutionNamePlaceholder.Application.Extensions;
using SolutionNamePlaceholder.Infrastructure.Extensions;
using SolutionNamePlaceholder.Presentation.Extensions;
using SolutionNamePlaceholder.Presentation.Middlewares;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.AddPresentation();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.

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

app.UseAuthorization();

app.MapControllers();

app.Run();
