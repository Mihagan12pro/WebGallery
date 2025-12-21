using Shared.Errors;

namespace WebGallery.Application.Services.Comments.Fails
{
    public partial class Errors
    {
        public static class Comments
        {
            public static Error LowReputation() =>
                Error.Failure("comment.low.reputation", "User reputation is too low!");
        }
    }
}
