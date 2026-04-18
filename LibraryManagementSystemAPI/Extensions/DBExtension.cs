using Microsoft.EntityFrameworkCore;
using Trining_RESTApi.Data;

namespace LibraryManagementSystemAPI.Extensions
{
    public static class DBExtension
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services , IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(op => op.UseSqlServer(configuration.GetConnectionString("MyCon")));
            return services;    
        }
    }
}
