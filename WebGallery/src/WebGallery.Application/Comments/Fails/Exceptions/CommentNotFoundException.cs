using Shared;
using WebGallery.Application.Exceptions;

namespace WebGallery.Application.Comments.Fails.Exceptions
{
    public class CommentNotFoundException : NotFoundException
    {
        protected CommentNotFoundException(IEnumerable<Error> error)
            : base(error)
        {
        }
    }
}
