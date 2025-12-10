using CSharpFunctionalExtensions;
using Shared.Errors;
using WebGallery.Contracts.Identification;

namespace WebGallery.Application.Identification
{
    public interface IIdentificationService
    {
        Task<Result<Guid, Failure>> Register(SignInDto request, CancellationToken cancellationToken);

        Task<Result<string, Failure>> Login(LoginDto request, CancellationToken cancellationToken);
    }
}
