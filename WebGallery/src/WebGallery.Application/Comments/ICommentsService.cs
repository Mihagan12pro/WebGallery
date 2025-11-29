using CSharpFunctionalExtensions;
using Shared.Errors;
using WebGallery.Contracts.Comments;

namespace WebGallery.Application.Comments;

public interface ICommentsService
{
    Task<Result<Guid, Failure>> Create(
        CreateCommentDto commentDto,
        CancellationToken cancellationToken);
}