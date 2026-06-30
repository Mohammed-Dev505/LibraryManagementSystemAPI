using LibraryManagementSystemAPI.Application.Services.Implementaions;
using LibraryManagementSystemAPI.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LibraryManagementSystemAPI.Application.Extensions
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

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
