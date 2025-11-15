using System.Text.Json;
using Shared;
using WebGallery.Application.Exceptions;

namespace WebGallery.Web.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private ILogger _logger;

        public async Task InvoleAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionsAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionsAsync(HttpContext context, Exception exception)
        {
            _logger.LogError(exception, exception.Message);

            (int code, IEnumerable <Error>? errors) = exception switch
            {
                BadHttpRequestException => (
                    StatusCodes.Status500InternalServerError,
                    JsonSerializer.Deserialize<IEnumerable<Error>>(exception.Message)),

                NotFoundException => (
                    StatusCodes.Status404NotFound,
                    JsonSerializer.Deserialize<IEnumerable<Error>>(exception.Message)
                ),

                _ => (StatusCodes.Status500InternalServerError, [Error.Failure(null, "Something went wrong")])
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = code;

            await context.Response.WriteAsJsonAsync(errors);
        }

        public ExceptionMiddleware(RequestDelegate next, ILogger logger)
        {
            _next = next;
            _logger = logger;
        }
    }
}
