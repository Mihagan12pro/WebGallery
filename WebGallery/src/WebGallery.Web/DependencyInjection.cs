using WebGallery.Application;
using WebGallery.Infrastracture.PostgreSql;
using WebGallery.Infrastructure.Security;

namespace WebGallery.Web;

public static class DependencyInjection
{
    public static IServiceCollection AddProgramDependencies(this IServiceCollection services)
    {
        return services.AddApplication().
            AddWebDependencies().
                AddPostgresInfrastructure().
                    AddSecurityInfrastructure();
    }

    private static IServiceCollection AddWebDependencies(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddOpenApi();

        return services;
    }
}