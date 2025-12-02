using System.Text.Json;
using Shared.Errors;

namespace WebGallery.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        protected NotFoundException(IEnumerable<Error> error)
            : base(JsonSerializer.Serialize(error))
        {
        }
    }
}
