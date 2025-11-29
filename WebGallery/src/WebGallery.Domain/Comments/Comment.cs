using System.Runtime.InteropServices.JavaScript;

namespace WebGallery.Domain.Comments;

public class Comment
{
    public Guid Id { get; set; }

    public List<Comment> Children { get; private set; } = [];

    public Guid UserId { get; set; }

    public Guid EntityId { get; set; }

    public DateTime DateTime { get; init; }

    public string Body { get; set; }

    public int Likes { get; set; }

    public int DisLikes { get; set; }

    public Comment(
        Guid id,
        Guid userId,
        Guid entityId,
        string body,
        int likes = 0,
        int disLikes = 0)
    {
        DateTime = DateTime.Now;
        Id = id;
        UserId = userId;
        EntityId = entityId;
        Body = body;
        Likes = likes;
        DisLikes = disLikes;
    }
}