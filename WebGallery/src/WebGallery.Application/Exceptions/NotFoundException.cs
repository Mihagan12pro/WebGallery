using System.Text.Json;
using Shared;

namespace WebGallery.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        protected NotFoundException(IEnumerable<Error> error)
            : base(JsonSerializer.Serialize(error))
        {
        }

        //protected NotFoundException(IEnumerable<string> errors)
        //    : base(string.Join(',', errors))
        //{
        //}
    }
}
