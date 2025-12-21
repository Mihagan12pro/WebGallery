using WebGallery.Application.Exceptions;
using WebGallery.Application.Services.Comments.Fails;

namespace WebGallery.Application.Services.Comments.Fails.Exceptions
{
    public class CommentLowReputationException : BadRequestException
    {
        public CommentLowReputationException()
            : base([Errors.Comments.LowReputation()])
        {
        }
    }
}
