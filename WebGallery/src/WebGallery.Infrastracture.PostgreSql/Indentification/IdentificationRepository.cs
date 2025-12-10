using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Shared.Errors;
using System.Text.Json;
using WebGallery.Application.Identification;
using WebGallery.Domain.Users;

namespace WebGallery.Infrastracture.PostgreSql.Indentification
{
    internal class IdentificationRepository : WebGalleryRepositoryBase, IIdentificationRepository
    {
        public async Task<Result<Guid, Error>> RegisterAsync(User user, CancellationToken cancellationToken)
        {
            await webGalleryContext.Users.AddAsync(user, cancellationToken);

            try
            {
                await webGalleryContext.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                if (e.InnerException is PostgresException postgresException)
                {
                    Error error = Error.Conflict(null, $"Duplicate key violates unique constraint: {postgresException.ConstraintName}");

                    return error;
                }
            }

            return user.Id;
        }

        public IdentificationRepository(WebGalleryContext context) 
            : base(context)
        {
        }
    }
}
