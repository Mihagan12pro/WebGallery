using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebGallery.Domain.Comments;
using WebGallery.Domain.Users;
using WebGallery.Infrastracture.PostgreSql.EntityConfigurations.Users.PivotTables;
using WebGallery.Infrastracture.PostgreSql.Options.Authorization;

namespace WebGallery.Infrastracture.PostgreSql;

public class WebGalleryContext : ContextBase
{
    public DbSet<Comment> Comments { get; set; } = null!;

    public DbSet<User> Users { get; set; } = null!;

    private readonly ICollection<RolePermissions> _rolePermissionsCollection;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

        modelBuilder.ApplyConfiguration(new RolePermissionConfiguration(_rolePermissionsCollection));
    }

    public WebGalleryContext(
        IConfiguration localConfiguration,
        IConfiguration globalConfiguration)
        : base(localConfiguration, globalConfiguration)
    {
        IConfigurationSection authorizationOptionsConfiguration = this.globalConfiguration.GetSection($"{nameof(AuthorizationOptions)}:{nameof(RolePermissions)}");

        _rolePermissionsCollection = [];
        authorizationOptionsConfiguration.Bind(_rolePermissionsCollection);

        Database.Migrate();
    }
}