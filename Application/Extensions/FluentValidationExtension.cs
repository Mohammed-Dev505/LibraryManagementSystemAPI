using FluentValidation;
using FluentValidation.AspNetCore;
using LibraryManagementSystemAPI.Application.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManagementSystemAPI.Application.Extensions
{
    public static class FluentValidationExtension
    {
        public static IServiceCollection AddValidationServices(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<RegisterUserValidator>();
            return services;

        }
    }
}
