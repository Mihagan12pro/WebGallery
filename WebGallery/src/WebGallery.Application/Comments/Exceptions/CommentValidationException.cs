using Shared;
using WebGallery.Application.Exceptions;

namespace WebGallery.Application.Comments.Exceptions
{
    public class CommentValidationException : BadRequestException
    {
        public CommentValidationException(IEnumerable<Error> errors)
            : base(errors)
        {
        }
    }
}
