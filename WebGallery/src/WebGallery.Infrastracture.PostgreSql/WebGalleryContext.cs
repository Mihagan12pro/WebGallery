using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebGallery.Domain.Comments;
using WebGallery.Domain.Users;

namespace WebGallery.Infrastracture.PostgreSql;

public class WebGalleryContext : ContextBase
{
    public DbSet<Comment> Comments { get; set; } = null!;

    public DbSet<User> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().
            Property(u => u.Email).
                HasColumnType("citext");

        modelBuilder.Entity<User>().
        Property(u => u.UserName).
            HasColumnType("citext");

        modelBuilder.Entity<User>().
            HasIndex(u => u.Email).
                IsUnique();


        modelBuilder.Entity<User>().
           HasIndex(u => u.UserName).
               IsUnique();

        modelBuilder.Entity<User>().
            HasKey(u => u.Id);
    }

    public WebGalleryContext(IConfiguration configuration)
        : base(configuration)
    {
    }
}