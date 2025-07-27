using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Serilog;

namespace Application.Moduels.Common.MiddleWare
{
    public static class ExceptionHandlingExtensions
    {
        public static IApplicationBuilder UseGlobalExceptionHandling(this IApplicationBuilder app)
        {
            return app.Use(async (context, next) =>
            {
                try
                {
                    await next();
                }
                catch (FluentValidation.ValidationException ex)
                {
                    context.Response.StatusCode = 400;
                    var errors = ex.Errors
                        .Select(e => new { e.PropertyName, e.ErrorMessage });

                    await context.Response.WriteAsJsonAsync(new { Errors = errors });
                }
                catch (Exception ex)
                {
                   
                    context.Response.StatusCode = 500;
                    await context.Response.WriteAsync($"An unexpected error occurred.{ex.Message}");
                }
            });
        }
    }

}
