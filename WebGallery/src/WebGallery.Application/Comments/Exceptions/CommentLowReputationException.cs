using Shared;
using WebGallery.Application.Exceptions;

namespace WebGallery.Application.Comments.Exceptions
{
    public class CommentLowReputationException : BadRequestException
    {
        public CommentLowReputationException(IEnumerable<Error> errors) : base(errors)
        {
        }
    }
}
