using LibraryManagementSystemAPI.Middleware;
using LibraryManagementSystemAPI.Services.Implementaions;
using LibraryManagementSystemAPI.Services.Interfaces;
using Trining_RESTApi.Services.Implementaions;
using Trining_RESTApi.Services.Interfaces;

namespace LibraryManagementSystemAPI.Extensions
{
    public static class ServicesExtension
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IBorrowService, BorrowService>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddTransient<ExceptionMiddleware>();
            return services;
        }
    }
}
