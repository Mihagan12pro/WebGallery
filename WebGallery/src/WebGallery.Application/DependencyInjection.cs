using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using WebGallery.Application.Services.Comments;
using WebGallery.Application.Services.Identification;

namespace WebGallery.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
        services.AddScoped<ICommentsService, CommentsService>();
        services.AddScoped<IIdentificationService, IdentificationService>();

        return services;
    }
}