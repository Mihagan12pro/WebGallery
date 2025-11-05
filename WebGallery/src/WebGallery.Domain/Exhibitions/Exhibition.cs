namespace WebGallery.Domain.Exhibitions;

public abstract class Exhibition
{
    public Guid  Id { get; set; }
    
    public ExhibitionVisibility Visibility { get; set; } =  ExhibitionVisibility.Private;
    
    public required string Tittle { get; set; }
    
    public string? Description { get; set; }
    
    public required Guid AuthorId { get; set; }
    
    public string MimeType { get; init; }
    
    public DateTime DateTime { get; init; }

    public Exhibition()
    {
        DateTime = DateTime.Now;
    }
}

public enum ExhibitionVisibility
{
    Public,
    
    Private
}
