using WebGallery.Contracts.Comments;
using WebGallery.Domain.Comments;

namespace WebGallery.Application.Comments;

public class CommentsService
{
    public async Task Create(
        CreateCommentDto commentDto, 
        CancellationToken cancellationToken)
    {
        //Проверка валидности

        Guid id = Guid.NewGuid();

        var comment = new Comment(id, commentDto.UserId, commentDto.EntityId, commentDto.Body);

        //Создание сущности Comment - сделано



        //Сохранение сущности Comment в базе данных

        //Логирование об успешном и неуспешном логировании
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