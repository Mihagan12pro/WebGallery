using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebGallery.Application;
using WebGallery.Application.Services.Identification;
using WebGallery.Domain.Users.Permissions;
using WebGallery.Infrastracture.PostgreSql;
using WebGallery.Infrastracture.PostgreSql.Options.Authorization;
using WebGallery.Infrastructure.Security;
using WebGallery.Infrastructure.Security.AuthorizationRequirements;

namespace WebGallery.Web;

public static class DependencyInjection
{
    public static IServiceCollection AddProgramDependencies(this IServiceCollection services)
    {
        services.AddWebDependencies().
            AddLayersDependencies();

        services.AddApiAuthentication();
        services.AddApiAuthorization();

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

    private static void AddApiAuthorization(this IServiceCollection services)
    {
        IServiceProvider serviceProvider = services.BuildServiceProvider();
        IConfiguration configuration = serviceProvider.GetService<IConfiguration>()!;

        IConfigurationSection authorizationOptionsConfiguration = configuration.GetSection($"{nameof(AuthorizationOptions)}:{nameof(RolePermissions)}");

        ICollection<RolePermissions> rolePermissions = [];
        authorizationOptionsConfiguration.Bind(rolePermissions);

        services.AddAuthorization(options =>
        {
            string[] permissions = rolePermissions
                .SelectMany(pr => pr.Permissions)
                    .Distinct()
                        .ToArray();

            foreach(string permission in permissions)
            {
                options.AddPolicy(permission, policy =>
                {
                    policy.AddRequirements(new PermissionRequirement(permission));
                });
            }
        });
    }

    private static void AddApiAuthentication(this IServiceCollection services)
    {
        IServiceProvider serviceProvider = services.BuildServiceProvider();

        IJwtProvider jwtProvider = serviceProvider.GetRequiredService<IJwtProvider>();
        IConfigurationRoot configuration = (IConfigurationRoot)serviceProvider.GetService<IConfiguration>()!;

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
                        context.Token = context.Request.Cookies[configuration.GetSection("Constants:cookie").Value];

                        return Task.CompletedTask;
                    }
                };
            });

        services.AddAuthorization();
    }
}