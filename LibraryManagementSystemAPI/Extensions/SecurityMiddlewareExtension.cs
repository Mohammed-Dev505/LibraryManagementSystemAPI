namespace LibraryManagementSystemAPI.Extensions
{
    public static class SecurityMiddlewareExtension
    {
        public static IApplicationBuilder UseSecurity(this IApplicationBuilder app)
        {
            app.UseAuthentication();

            app.UseAuthorization();

            return app;
        }
    }
}
