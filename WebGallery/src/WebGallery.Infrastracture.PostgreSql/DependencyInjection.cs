using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebGallery.Application.Services.Comments;
using WebGallery.Application.Services.Identification;
using WebGallery.Application.Services.Users;
using WebGallery.Infrastracture.PostgreSql.Repositories.Comments;
using WebGallery.Infrastracture.PostgreSql.Repositories.Indentification;
using WebGallery.Infrastracture.PostgreSql.Repositories.Users;

namespace WebGallery.Infrastracture.PostgreSql;

public static class DependencyInjection
{
    private static IConfigurationBuilder? _configurationBuilder = null;

    private static IConfigurationRoot? _postgreConfigurationRoot = null;

    public static IServiceCollection AddPostgresInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<WebGalleryContext>();

        services.AddScoped<ICommentsRepository, CommentsCoreRepository>();
        services.AddScoped<IIdentificationRepository, IdentificationRepository>();
        services.AddScoped<IUsersRepository, UsersRepository>();

        return services;
    }

    public static IConfiguration AddPsotgresConfiguration(this IConfiguration configuration)
    {
        string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Configuration");

        _configurationBuilder = new ConfigurationBuilder().
            SetBasePath(path).
                AddJsonFile("DbConfiguration.json");

        _postgreConfigurationRoot = _configurationBuilder.Build();

        return _postgreConfigurationRoot;
    }
}