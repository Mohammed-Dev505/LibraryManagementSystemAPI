using Microsoft.OpenApi.Models;

namespace LibraryManagementSystemAPI.Extensions
{
    public static class SwaggerExtension
    {
        public static IServiceCollection AddSwaggerExtenion(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Library Management System API",
                    Version = "v1",
                    Description = "لوحة التحكم واختبار خدمات نظام ادارة المكتبة المؤمن ب JWT"
                });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "ضع ال Token الخاص بك مباشرة في الحقل (بدون كتابة كلمة Bearer)"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                   {
                       new OpenApiSecurityScheme
                       {
                           Reference = new OpenApiReference
                           {
                               Type = ReferenceType.SecurityScheme,
                               Id = "Bearer"
                           }
                       },
                       Array.Empty<string>()
                   }
                });
            });

            return services;
        }
    }
}
