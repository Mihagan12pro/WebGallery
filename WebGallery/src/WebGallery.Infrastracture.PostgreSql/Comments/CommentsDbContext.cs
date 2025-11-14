using Microsoft.EntityFrameworkCore;
using WebGallery.Application;
using WebGallery.Domain.Comments;

namespace WebGallery.Infrastracture.PostgreSql.Comments;

public class CommentsDbContext : DbContext
{
    public DbSet<Comment> Comments { get; set; }
}