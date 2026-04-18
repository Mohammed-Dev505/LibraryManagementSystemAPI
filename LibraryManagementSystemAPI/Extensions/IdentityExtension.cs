using Microsoft.AspNetCore.Identity;
using Trining_RESTApi.Data;
using Trining_RESTApi.Data.Models;

namespace LibraryManagementSystemAPI.Extensions
{
    public static class IdentityExtension
    {
        public static IServiceCollection AddIdentityService(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
            return services;
        }
    }
}
