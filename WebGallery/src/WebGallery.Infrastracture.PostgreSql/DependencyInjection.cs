using Microsoft.Extensions.DependencyInjection;
using WebGallery.Application.Comments;
using WebGallery.Application.Database;
using WebGallery.Infrastracture.PostgreSql.Comments;
using WebGallery.Infrastracture.PostgreSql.Repositories;

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

        services.AddDbContext<CommentsDbContext>();

        services.AddScoped<ICommentsRepository, CommentsEFCoreRepository>();

        return services;
    }
}