using Shared.Errors;
using WebGallery.Application.Exceptions;

namespace WebGallery.Application.Comments.Fails.Exceptions
{
    public class CommentValidationException : BadRequestException
    {
        public CommentValidationException(IEnumerable<Error> errors)
            : base(errors)
        {
        }
    }
}
