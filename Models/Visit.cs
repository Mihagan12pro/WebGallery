namespace WebGallery.Models
{
    public record Visit(string Path, string method, DateOnly Date, TimeOnly Time);
}
