using CSharpFunctionalExtensions;
using Shared.Errors;
using WebGallery.Contracts.Identification;

namespace WebGallery.Application.Identification
{
    internal class IdentificationService : IIdentificationService
    {
        public Task<Result<string, Failure>> Login(LoginDto request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Result<string, Failure>> Register(SignInDto request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
