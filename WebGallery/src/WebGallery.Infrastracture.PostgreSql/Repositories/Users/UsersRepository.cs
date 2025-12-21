using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using Shared.Errors;
using WebGallery.Application.Services.Users;
using WebGallery.Domain.Users;

namespace WebGallery.Infrastracture.PostgreSql.Repositories.Users
{
    internal class UsersRepository :
        WebGalleryRepositoryBase, IUsersRepository
    {
        public async Task<Result<User, Error>> GetUserByUserNameAsync(string userName, CancellationToken cancellationToken)
        {
            User? user = await webGalleryContext.Users.
                FirstOrDefaultAsync(u => u.UserName == userName);

            if (user == null)
            {
                return Error.Failure(null, "User not found!");
            }

            return user;
        }

        public UsersRepository(WebGalleryContext context)
            : base(context)
        {
        }
    }
}
