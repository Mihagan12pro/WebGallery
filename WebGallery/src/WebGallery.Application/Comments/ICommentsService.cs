using WebGallery.Contracts.Comments;

namespace WebGallery.Application.Comments;

public interface ICommentsService
{
    Task<Guid> Create(
        CreateCommentDto commentDto,
        CancellationToken cancellationToken);
}