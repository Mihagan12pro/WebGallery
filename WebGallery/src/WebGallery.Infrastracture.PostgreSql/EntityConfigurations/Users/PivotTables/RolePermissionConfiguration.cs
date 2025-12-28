using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebGallery.Domain.Users.PivotTables;
using WebGallery.Infrastracture.PostgreSql.Options.Authorization;

namespace WebGallery.Infrastracture.PostgreSql.EntityConfigurations.Users.PivotTables
{
    internal class RolePermissionConfiguration
        : IEntityTypeConfiguration<RolePermission>
    {
        private readonly AuthorizationOptions _authorizationOptions;

        public void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            builder.HasKey(r => new { r.RoleId, r.PermissionId });
        }

        public RolePermissionConfiguration(AuthorizationOptions authorizationOptions)
        {
            _authorizationOptions = authorizationOptions;
        }
    }
}
