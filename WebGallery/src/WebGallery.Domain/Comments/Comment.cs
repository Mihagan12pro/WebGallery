namespace WebGallery.Domain.Comments;

public class Comment
{
    public Guid Id { get; set; }

    public List<Comment> Children { get; private set; } = [];

    required public Guid UserId { get; set; }

    required public Guid EntityId { get; set; }

    public DateTime DateTime { get; init; }

    required public string Body { get; set; }

    public Comment()
    {
        DateTime = DateTime.Now;
    }
}