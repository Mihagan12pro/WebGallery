using Microsoft.EntityFrameworkCore;
using WebGallery.Application;
using WebGallery.Domain.Comments;

namespace WebGallery.Infrastracture.PostgreSql;

public class WebGalleryContext : DbContext
{
    public DbSet<Comment> Comments { get; set; }
}