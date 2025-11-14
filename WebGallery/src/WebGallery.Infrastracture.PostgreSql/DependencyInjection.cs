using Microsoft.Extensions.DependencyInjection;
using WebGallery.Application;
using WebGallery.Application.Comments;
using WebGallery.Infrastracture.PostgreSql.Comments;
using WebGallery.Infrastracture.PostgreSql.Repositories;

namespace WebGallery.Infrastracture.PostgreSql;

public static class DependencyInjection
{
    public static IServiceCollection AddPostgresInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<ISqlConnectionFactory, SqlConnectionFactory>();
        services.AddScoped<ICommentsRepository, CommentsDapperRepository>();

        return services;
    }
}