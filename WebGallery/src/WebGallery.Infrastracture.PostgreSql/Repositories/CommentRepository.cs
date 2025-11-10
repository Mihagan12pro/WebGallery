using WebGallery.Application.Comments;
using WebGallery.Domain.Comments;

namespace WebGallery.Infrastracture.PostgreSql.Repositories;

public class CommentRepository : ICommentsRepository
{
    public async Task<Guid> AddAsync(Comment comment, CancellationToken cancellationToken) => throw new NotImplementedException();

    public async Task<Guid> UpdateAsync(Comment comment, CancellationToken cancellationToken) => throw new NotImplementedException();

    public async Task<Comment> GetByIdAsync(Guid id, CancellationToken cancellationToken) => throw new NotImplementedException();

    public async Task<Guid> DeleteAsync(Comment comment, CancellationToken cancellationToken) => throw new NotImplementedException();

    public async Task<int> GetUserReputationAsync(Guid userId, CancellationToken cancellationToken) => throw new NotImplementedException();
}