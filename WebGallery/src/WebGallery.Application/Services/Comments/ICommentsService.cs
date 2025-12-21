using CSharpFunctionalExtensions;
using Shared.Errors;
using WebGallery.Contracts.Comments;

namespace WebGallery.Application.Services.Comments;

public interface ICommentsService
{
    Task<Result<Guid, Failure>> Create(
        CreateCommentDto commentDto,
        CancellationToken cancellationToken);
}