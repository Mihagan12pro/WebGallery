using System.Reflection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebGallery.Application.Services.Identification;
using WebGallery.Infrastructure.Security.Handlers;
using WebGallery.Infrastructure.Security.Jwt;
using WebGallery.Infrastructure.Security.PasswordHashers;

namespace WebGallery.Infrastructure.Security
{
    public static class DependenciesInjection
    {
        private static IConfiguration? _configuration;

        public static IServiceCollection AddSecurityInfrastructure(this IServiceCollection services)
        {
            _configuration = AddSecurityConfiguration();

            services.AddScoped<IJwtProvider, JwtProvider>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.Configure<JwtOptions>(_configuration.GetSection(nameof(JwtOptions)));
            services.AddSingleton<IAuthorizationHandler, PermissionRequirementsHandler>();

            return services;
        }

        private static IConfiguration AddSecurityConfiguration()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Configuration");

            IConfigurationRoot configuration = new ConfigurationBuilder().
                SetBasePath(path).
                    AddJsonFile("SecurityConfiguration.json").
                        Build();

            return configuration;
        }
    }
}
