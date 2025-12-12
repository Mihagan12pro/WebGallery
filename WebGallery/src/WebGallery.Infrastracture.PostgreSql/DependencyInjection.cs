using Microsoft.Extensions.DependencyInjection;
using WebGallery.Application.Comments;
using WebGallery.Application.Identification;
using WebGallery.Infrastracture.PostgreSql.Repositories.Comments;
using WebGallery.Infrastracture.PostgreSql.Repositories.Indentification;

namespace WebGallery.Infrastracture.PostgreSql;

public static class DependencyInjection
{
    public static IServiceCollection AddPostgresInfrastructure(this IServiceCollection services)
    {
        /// <summary>
        /// For Dapper
        /// </summary>

        // services.AddSingleton<ISqlConnectionFactory, SqlConnectionFactory>();

        // services.AddScoped<ICommentsRepository, CommentsDapperRepository>();

        /// <summary>
        /// For EF Core
        /// </summary>

        services.AddDbContext<WebGalleryContext>();

        services.AddScoped<ICommentsRepository, CommentsCoreRepository>();
        services.AddScoped<IIdentificationRepository, IdentificationRepository>();

        return services;
    }
}