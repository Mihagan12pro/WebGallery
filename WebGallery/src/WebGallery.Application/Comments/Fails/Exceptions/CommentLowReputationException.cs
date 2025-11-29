using WebGallery.Application.Exceptions;

namespace WebGallery.Application.Comments.Fails.Exceptions
{
    public class CommentLowReputationException : BadRequestException
    {
        public CommentLowReputationException()
            : base([Errors.Comments.LowReputation()])
        {
        }
    }
}
