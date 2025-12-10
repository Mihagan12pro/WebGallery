using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
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

        string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, "Configuration", "DbConfiguration.json");

        configurationBuilder.AddJsonFile(path);

        var configurationRoot = configurationBuilder.Build();

        var connectionString = configurationRoot.
            GetConnectionString("GalleryDbContext");

        optionsBuilder.UseNpgsql(connectionString);
    }

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

    public WebGalleryContext()
    {
        Database.EnsureCreated();
    }
}