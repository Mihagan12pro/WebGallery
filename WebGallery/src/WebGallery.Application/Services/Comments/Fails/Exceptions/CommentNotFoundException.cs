using Shared.Errors;
using WebGallery.Application.Exceptions;

namespace WebGallery.Application.Services.Comments.Fails.Exceptions
{
    public class CommentNotFoundException : NotFoundException
    {
        protected CommentNotFoundException(IEnumerable<Error> error)
            : base(error)
        {
        }
    }
}
