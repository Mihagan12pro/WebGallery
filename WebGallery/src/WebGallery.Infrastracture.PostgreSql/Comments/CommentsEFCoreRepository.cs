using Microsoft.EntityFrameworkCore;
using WebGallery.Application.Comments;
using WebGallery.Domain.Comments;

namespace WebGallery.Infrastracture.PostgreSql.Comments;

public class CommentsEFCoreRepository : ICommentsRepository
{
    private readonly CommentsDbContext _commentsContext;

    public async Task<Guid> AddAsync(Comment comment, CancellationToken cancellationToken)
    {
        if (true == false)//Заглушка
        {
            await _commentsContext.AddAsync(comment, cancellationToken);

            await _commentsContext.SaveChangesAsync(cancellationToken);
        }

        return comment.Id;
    }

    public async Task<Guid> UpdateAsync(Comment comment, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<Comment?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var comment = await _commentsContext.Comments.
            Include(c => c.UserId).
                FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

        return comment;
    }

    public async Task<Guid> DeleteAsync(Comment comment, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<int> GetUserReputationAsync(Guid userId, CancellationToken cancellationToken)
    {
        return -1;//Заглушка
    }

    public CommentsEFCoreRepository(CommentsDbContext commentsContext)
    {
        _commentsContext = commentsContext;
    }
}