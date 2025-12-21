using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using Shared.Errors;
using Shared.Errors.Common;
using WebGallery.Application.Services.Identification;
using WebGallery.Domain.Users;
using WebGallery.Infrastracture.PostgreSql.Extensions;

namespace WebGallery.Infrastracture.PostgreSql.Repositories.Indentification
{
    internal class IdentificationRepository : WebGalleryRepositoryBase, IIdentificationRepository
    {
        public async Task<Result<Guid, Failure>> RegisterAsync(User user, CancellationToken cancellationToken)
        {
            Failure? errors = new Failure([]);

            var result = await webGalleryContext.
                CheckUniqueConstrait<User>(
                    user,
                    nameof(user.Email),
                    user.Email!,
                    "This email is already taken!");

            if (result.IsFailure)
                errors.Add(result.Error);

            result = await webGalleryContext.
                CheckUniqueConstrait<User>(
                    user,
                    nameof(user.UserName),
                    user.UserName!,
                    "This user name is already taken!");

            if (result.IsFailure)
                errors.Add(result.Error);

            if (errors.Count() > 0)
                return errors;

            await webGalleryContext.Users.AddAsync(user, cancellationToken);

            await webGalleryContext.SaveChangesAsync();

            return user.Id;
        }

        public async Task<Result<string, Failure>> GetPasswordHashAsync(string userName, CancellationToken cancellationToken)
        {
            User? user = await webGalleryContext.Users.FirstAsync(u => u.UserName == userName);


            if (user == null)
                return new InvalidPasswordOrLoginError().Failure;

            return user.PasswordHash!;
        }

        public IdentificationRepository(WebGalleryContext context)
            : base(context)
        {
        }
    }
}
