using System.Text.Json;
using Shared;

namespace WebGallery.Application.Exceptions
{
    public class BadRequestException : Exception
    {
        protected BadRequestException(IEnumerable<Error> errors)
            : base(JsonSerializer.Serialize(errors))
        {
        }
    }
}
