using FluentValidation;
using FluentValidation.AspNetCore;
using LibraryManagementSystemAPI.Validators;

namespace LibraryManagementSystemAPI.Extensions
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
