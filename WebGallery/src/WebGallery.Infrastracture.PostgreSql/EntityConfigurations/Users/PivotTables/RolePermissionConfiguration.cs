using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebGallery.Domain.Users.PivotTables;
using WebGallery.Infrastracture.PostgreSql.Options.Authorization;
using Permission = WebGallery.Infrastracture.PostgreSql.Enums.Permission;
using Role = WebGallery.Infrastracture.PostgreSql.Enums.Role;

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
            foreach(var rp in _rolePermissionsCollection)
            {
                var RoleId = (int)Enum.Parse<Role>(rp.Role);
            }

            return _rolePermissionsCollection
                .SelectMany(rp => rp.Permissions
                    .Select(p => new RolePermission
                    {
                        RoleId = (int)Enum.Parse<Role>(rp.Role),

                        PermissionId = (int)Enum.Parse<Permission>(p)
                    })
                ).ToArray()!;
        }

        public RolePermissionConfiguration(ICollection<RolePermissions> rolePermissionsCollection)
        {
           _rolePermissionsCollection = rolePermissionsCollection;
        }
    }
}
