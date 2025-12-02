using CSharpFunctionalExtensions;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Shared.Errors;
using WebGallery.Application.Comments.Fails;
using WebGallery.Application.Comments.Fails.Exceptions;
using WebGallery.Application.Extensions;
using WebGallery.Contracts.Comments;
using WebGallery.Domain.Comments;

namespace WebGallery.Application.Comments;

public class CommentsService : ICommentsService
{
    private readonly ICommentsRepository _commentsRepository;
    private readonly ILogger<CommentsService> _logger;
    private readonly IValidator<CreateCommentDto> _creationValidator;

    public CommentsService(
        ICommentsRepository commentsRepository,
        IValidator<CreateCommentDto>creationValidator,
        ILogger<CommentsService> logger)
    {
        _commentsRepository = commentsRepository;
        _logger = logger;
        _creationValidator = creationValidator;
    }

    public async Task<Result<Guid, Failure>> Create(
        CreateCommentDto commentDto,
        CancellationToken cancellationToken)
    {
        var validationResult = await _creationValidator.ValidateAsync(commentDto, cancellationToken);
        if (!validationResult.IsValid)
        {
            return validationResult.ToErrors();
        }

        Guid commentId = Guid.NewGuid();

        if (await _commentsRepository.GetUserReputationAsync(commentDto.UserId, cancellationToken) < 0)
        {
            return Errors.Comments.
                LowReputation().
                    ToCollection();
        }

        var comment = new Comment(commentId, commentDto.UserId, commentDto.EntityId, commentDto.Body);

        await _commentsRepository.AddAsync(comment, cancellationToken);

        _logger.LogInformation($"Comment created with id {commentId}", commentId);

        return commentId;
    }

    /*public async Task<IActionResult> Get(
        GetCommentsByExhibitionDto request,
        CancellationToken cancellationToken)
    {
        return Ok("Get all comments");
    }


    public async Task<IActionResult> GetById(
        Guid commentId,
        CancellationToken cancellationToken)
    {
        return Ok("Get comment by id");
    }

    
    public async Task<IActionResult> Update(
        Guid commentId,
        UpdateCommentDto request,
        CancellationToken cancellationToken)
    {
        return Ok("Update comment");
    }
    
    
    public async Task<IActionResult>  RateComment(
        [Guid commentId, 
        RateCommentDto request,
        CancellationToken cancellationToken)
    {
        return Ok("Rate comment");
    }
    
    
    public async Task<IActionResult> Delete(
        Guid commentId,
        CancellationToken cancellationToken)
    {
        return Ok("Delete comment");
    }*/
}