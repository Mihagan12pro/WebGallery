using Shared;
using WebGallery.Application.Exceptions;

namespace WebGallery.Application.Comments.Exceptions
{
    public class CommentNotFoundException : NotFoundException
    {
        public CommentNotFoundException(IEnumerable<Error> errors)
            : base(errors)
        {
        }
    }
}
