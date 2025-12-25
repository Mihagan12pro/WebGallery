using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebGallery.Application;
using WebGallery.Application.Services.Identification;
using WebGallery.Infrastracture.PostgreSql;
using WebGallery.Infrastructure.Security;

namespace WebGallery.Web;

public static class DependencyInjection
{
    public static IServiceCollection AddProgramDependencies(this IServiceCollection services)
    {
        services.AddWebDependencies().
            AddLayersDependencies();

        services.AddApiAuthentification();

        return services;
    }

    private static IServiceCollection AddLayersDependencies(this IServiceCollection services)
    {
        return services.
            AddApplication().
                AddPostgresInfrastructure().
                    AddSecurityInfrastructure();
    }

    private static IServiceCollection AddWebDependencies(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddOpenApi();

        return services;
    }

    private static void AddApiAuthentification(
        this IServiceCollection services)
    {
        IServiceProvider serviceProvider = services.BuildServiceProvider();

        IJwtProvider jwtProvider = serviceProvider.GetRequiredService<IJwtProvider>();
        IConfiguration configuration = serviceProvider.GetService<IConfiguration>()!;

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).
            AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtProvider.SecretKey))
                };

                options.Events = new JwtBearerEvents()
                {
                    OnMessageReceived = context =>
                    {
                        context.Token = context.Request.Cookies[configuration.GetSection("cookie-title").ToString()];

                        return Task.CompletedTask;
                    }
                };
            });

        services.AddAuthorization();
    }
}