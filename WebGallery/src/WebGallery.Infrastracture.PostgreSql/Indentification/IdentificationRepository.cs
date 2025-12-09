using CSharpFunctionalExtensions;
using Shared.Errors;
using WebGallery.Application.Identification;
using WebGallery.Domain.Users;

namespace WebGallery.Infrastracture.PostgreSql.Indentification
{
    internal class IdentificationRepository : IIdentificationRepository
    {
        public Task<Result<Guid, Error>> RegisterAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
