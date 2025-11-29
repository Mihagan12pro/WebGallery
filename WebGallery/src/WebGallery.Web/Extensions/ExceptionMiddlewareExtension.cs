using WebGallery.Web.Middlewares;

namespace WebGallery.Web.Extensions
{
    public static class ExceptionMiddlewareExtension
    {
        public static IApplicationBuilder UseExceptionMiddleware(this WebApplication app) =>
            app.UseMiddleware<ExceptionMiddleware>();
    }
}
