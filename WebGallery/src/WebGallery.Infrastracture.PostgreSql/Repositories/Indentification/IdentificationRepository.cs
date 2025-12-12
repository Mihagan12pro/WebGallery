using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Shared.Errors;
using WebGallery.Application.Identification;
using WebGallery.Domain.Users;

namespace WebGallery.Infrastracture.PostgreSql.Repositories.Indentification
{
    internal class IdentificationRepository : WebGalleryRepositoryBase, IIdentificationRepository
    {
        public async Task<Result<Guid, Failure>> RegisterAsync(User user, CancellationToken cancellationToken)
        {
            List<Error> errors = new List<Error>();

            var dublicateName = await webGalleryContext.Users.
                Select(u => u.UserName).
                    FirstOrDefaultAsync(n => n == user.UserName);

            if (dublicateName != null)
                errors.Add(DbErrorMaster.GetUniqueConstaitError("This user name is already taken!", nameof(user.UserName)));

            var dublicateEmail = await webGalleryContext.Users.
                    Select(u => u.Email).
                        FirstOrDefaultAsync(e => e == user.Email);

            if (dublicateEmail != null)
                errors.Add(DbErrorMaster.GetUniqueConstaitError("This email is already taken!", nameof(user.Email)));

            if (errors.Count > 0)
            {
                return new Failure(errors);
            }

            await webGalleryContext.Users.AddAsync(user, cancellationToken);

            await webGalleryContext.SaveChangesAsync();

            return user.Id;
        }

        public IdentificationRepository(WebGalleryContext context) 
            : base(context)
        {
        }
    }
}
