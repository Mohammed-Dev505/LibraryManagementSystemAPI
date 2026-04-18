using LibraryManagementSystemAPI.Middleware;

namespace LibraryManagementSystemAPI.Extensions
{
    public static class MiddlewareExtension
    {
        public static IApplicationBuilder UseGlobalException(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
            return app;
        }
    }
}
