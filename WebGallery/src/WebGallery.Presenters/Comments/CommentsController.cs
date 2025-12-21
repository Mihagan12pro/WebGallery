using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebGallery.Application.Services.Comments;
using WebGallery.Contracts.Comments;

namespace WebGallery.Presenters.Comments;

[ApiController]
[Route("api/[controller]")]
public class CommentsController : ControllerBase
{
    private readonly ICommentsService _commentsService;

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create(
        [FromBody] CreateCommentDto request,
        CancellationToken cancellationToken)
    {
        var response = await _commentsService.Create(request, cancellationToken);

        if (response.IsFailure)
        {
            return response.Error.ToErrorResponse();
        }

        return Ok(response.Value);
    }

    [HttpGet]
    public async Task<IActionResult> Get(
        [FromQuery] GetCommentsByExhibitionDto request,
        CancellationToken cancellationToken)
    {
        return Ok("Get all comments");
    }

    [HttpGet("{commentId:guid}")]
    public async Task<IActionResult> GetById(
        [FromRoute] Guid commentId,
        CancellationToken cancellationToken)
    {
        return Ok("Get comment by id");
    }

    [HttpPut("{commentId:guid}")]
    [Authorize]
    public async Task<IActionResult> Update(
        [FromRoute] Guid commentId,
        UpdateCommentDto request,
        CancellationToken cancellationToken)
    {
        return Ok("Update comment");
    }

    [HttpPatch("{commentId:guid}/rate")]
    [Authorize]
    public async Task<IActionResult> RateComment(
        [FromRoute] Guid commentId,
        RateCommentDto request,
        CancellationToken cancellationToken)
    {
        return Ok("Rate comment");
    }

    [HttpDelete("{commentId:guid}")]
    [Authorize]
    public async Task<IActionResult> Delete(
        [FromRoute] Guid commentId,
        CancellationToken cancellationToken)
    {
        return Ok("Delete comment");
    }

    public CommentsController(ICommentsService commentsService)
    {
        _commentsService = commentsService;
    }
}