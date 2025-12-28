using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using WebGallery.Domain.Comments;
using WebGallery.Domain.Users;
using WebGallery.Infrastracture.PostgreSql.EntityConfigurations.Users.Permissions;
using WebGallery.Infrastracture.PostgreSql.Options.Authorization;

namespace WebGallery.Infrastracture.PostgreSql;

public class WebGalleryContext : ContextBase
{
    public DbSet<Comment> Comments { get; set; } = null!;

    public DbSet<User> Users { get; set; } = null!;

    private readonly IOptions<AuthorizationOptions> _authOptions;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

        //modelBuilder.ApplyConfiguration(new PermissionConfiguration());
    }

    public WebGalleryContext(
        IConfiguration configuration,
        IOptions<AuthorizationOptions> authOptions)
        : base(configuration)
    {
        _authOptions = authOptions;
    }
}