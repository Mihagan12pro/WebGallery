namespace WebGallery.Domain.Comments;

public class Comment
{
    public Guid Id { get; set; }

    public List<Comment> Children = [];

    public required Guid UserId { get; set; }
    
    public required Guid EntityId { get; set; }
    
    public DateTime DateTime { get; init; }
    
    public Comment()
    {
        DateTime =  DateTime.Now;
    }
}