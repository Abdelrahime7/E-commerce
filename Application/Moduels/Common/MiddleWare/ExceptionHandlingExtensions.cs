using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Application.Moduels.Common.MiddleWare
{
    public static class ExceptionHandlingExtensions
    {
        private static ILogger? _logger;

        public static void ConfigureLogger(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger("GlobalExceptionHandler");
        }

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
                    _logger?.LogWarning(ex, "Validation failed for request");
                    context.Response.StatusCode = 400;
                    var errors = ex.Errors
                        .Select(e => new { e.PropertyName, e.ErrorMessage });

                    await context.Response.WriteAsJsonAsync(new { Errors = errors });
                }
                catch (Exception ex)
                {
                    _logger?.LogError(ex, "Unhandled exception occurred");
                    context.Response.StatusCode = 500;
                    await context.Response.WriteAsJsonAsync(new
                    {
                        Error = "An unexpected error occurred.",
                        Details = ex.Message
                    });
                }
            });
        }
    }


}
