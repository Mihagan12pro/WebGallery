using CSharpFunctionalExtensions;
using Shared.Errors;
using WebGallery.Domain.Users;

namespace WebGallery.Application.Services.Users
{
    public interface IUsersRepository
    {
        Task<Result<User, Error>> GetUserByUserNameAsync(string userName, CancellationToken cancellationToken);
    }
}
