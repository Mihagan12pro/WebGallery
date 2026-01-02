using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebGallery.Domain.Users.Permissions;
using WebGallery.Domain.Users.PivotTables;
using WebGallery.Domain.Users.Roles;
using WebGallery.Infrastracture.PostgreSql.Options.Authorization;

namespace WebGallery.Infrastracture.PostgreSql.EntityConfigurations.Users.PivotTables
{
    internal class RolePermissionConfiguration
        : IEntityTypeConfiguration<RolePermission>
    {
        private readonly ICollection<RolePermissions> _rolePermissionsCollection;

        public void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            builder.HasKey(r => new { r.RoleId, r.PermissionId });

            builder.HasData(ParseRolePermissions());
        }

        private RolePermission[] ParseRolePermissions()
        {
            return _rolePermissionsCollection
                .SelectMany(rp => rp.Permissions
                    .Select(p => new RolePermission
                    {
                        RoleId = (int)Enum.Parse<Enums.Role>(rp.Role),

                        PermissionId = (int)Enum.Parse<Enums.Permission>(p)
                    })
                ).ToArray();
        }

        public RolePermissionConfiguration(ICollection<RolePermissions> rolePermissionsCollection)
        {
           _rolePermissionsCollection = rolePermissionsCollection;
        }
    }
}
