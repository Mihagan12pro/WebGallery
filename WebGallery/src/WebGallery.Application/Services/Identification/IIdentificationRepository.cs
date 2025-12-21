using CSharpFunctionalExtensions;
using Shared.Errors;
using WebGallery.Domain.Users;

namespace WebGallery.Application.Services.Identification
{
    public interface IIdentificationRepository
    {
        Task<Result<Guid, Failure>> RegisterAsync(User user, CancellationToken cancellationToken);

        Task<Result<string, Failure>> GetPasswordHashAsync(string userName, CancellationToken cancellationToken);
    }
}
