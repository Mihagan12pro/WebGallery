using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using WebGallery.Domain.Comments;
using WebGallery.Domain.Users;

namespace WebGallery.Infrastracture.PostgreSql;

public class WebGalleryContext : DbContext
{
    public DbSet<Comment> Comments { get; set; } = null!;

    public DbSet<User> Users { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configurationBuilder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory());

        configurationBuilder.AddJsonFile("DbConfiguration.json");

        var configurationRoot = configurationBuilder.Build();

        var connectionString = configurationRoot.
            GetConnectionString("GalleryDbContext");

        optionsBuilder.UseNpgsql(connectionString);
    }
}