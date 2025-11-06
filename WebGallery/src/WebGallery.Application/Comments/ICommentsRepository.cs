using WebGallery.Domain.Comments;

namespace WebGallery.Application.Comments;

public interface ICommentsRepository
{
    Task<Guid> AddAsync(Comment comment, CancellationToken cancellationToken);
    
    Task<Guid> UpdateAsync(Comment comment, CancellationToken cancellationToken);
    
    Task<Comment> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    
    Task<Guid> DeleteAsync(Comment comment, CancellationToken cancellationToken);
}