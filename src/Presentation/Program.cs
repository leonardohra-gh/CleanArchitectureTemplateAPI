using SolutionNamePlaceholder.Application.Extensions;
using SolutionNamePlaceholder.Infrastructure.Extensions;
using SolutionNamePlaceholder.Presentation.Extensions;
using SolutionNamePlaceholder.Presentation.Middlewares;
using Serilog;
using SolutionNamePlaceholder.Infrastructure.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.AddPresentation();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.AddPresentation();
app.AddInfrastructure();

app.Run();
