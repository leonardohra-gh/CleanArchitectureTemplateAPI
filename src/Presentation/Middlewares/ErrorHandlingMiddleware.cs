using Domain.Exceptions;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Presentation.Middlewares
{
    public class ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger) : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (CustomException ex)
            {
                context.Response.StatusCode = ex.StatusCode;
                await context.Response.WriteAsync(ex.Message);
                logger.LogWarning("{@ex}", ex);
            }
            catch (Exception ex)
            {
                logger.LogError("{ex} - {exMessage}", ex, ex.Message);
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Erro interno, favor avisar ao administrador do sistema com horário do erro.");
            }
        }
    }
}
