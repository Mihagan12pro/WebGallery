using CSharpFunctionalExtensions;
using Shared.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGallery.Domain.Users;

namespace WebGallery.Application.Identification
{
    public interface IIdentificationRepository
    {
        Task<Result<Guid, Error>> RegisterAsync(User user, CancellationToken cancellationToken);
    }
}
