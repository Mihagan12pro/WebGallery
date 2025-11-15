using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using WebGallery.Application.Comments;
using WebGallery.Application.Database;
using WebGallery.Domain.Comments;

namespace WebGallery.Infrastracture.PostgreSql.Repositories;

public class CommentsDapperRepository : ICommentsRepository
{
    private readonly ISqlConnectionFactory _connectionFactory;

    public async Task<Guid> AddAsync(Comment comment, CancellationToken cancellationToken)
    {
        const string sql = """
                           INSERT INTO comments (body, user_id, entity_id) 
                           VALUES (@body, @user_id, @entity_id)
                           """;

        using var sqlConnection = _connectionFactory.CreateConnection();

        await sqlConnection.ExecuteAsync(sql, new
        {
            Body = comment.Body,
            userId =  comment.UserId,
            entityId = comment.EntityId
        });
        
        return comment.Id;
    }

    public async Task<Guid> UpdateAsync(Comment comment, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<Comment> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<Guid> DeleteAsync(Comment comment, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<int> GetUserReputationAsync(Guid userId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }


    public CommentsDapperRepository(ISqlConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }
}