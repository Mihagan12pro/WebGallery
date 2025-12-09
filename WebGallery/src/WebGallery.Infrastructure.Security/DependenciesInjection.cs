using Microsoft.Extensions.DependencyInjection;
using WebGallery.Infrastructure.Security.Jwt;
using WebGallery.Infrastructure.Security.PasswordHashers;

namespace WebGallery.Infrastructure.Security
{
    public static class DependenciesInjection
    {
        public static IServiceCollection AddSecurityInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IJwtProvider, JwtProvider>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();

            return services;
        }
    }
}
