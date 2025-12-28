using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebGallery.Domain.Users.PivotTables;
using Permission = WebGallery.Domain.Users.Permissions.Permission;
using Role = WebGallery.Domain.Users.Roles.Role;

namespace WebGallery.Infrastracture.PostgreSql.EntityConfigurations.Users.Roles
{
    internal class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(r => r.Id);

            builder.HasMany(r => r.Permissions).
                WithMany(p => p.Roles).
                    UsingEntity<RolePermission>(
                    l => l.HasOne<Permission>().WithMany().HasForeignKey(rp => rp.PermissionId),
                    r => r.HasOne<Role>().WithMany().HasForeignKey(rp => rp.RoleId)
                );

            IEnumerable<Role> roles = Enum.
                GetValues<Enums.Role>().Select(r => new Role
                {
                    Id = (int)r,

                    Name = r.ToString()
                });

            builder.HasData(roles);
        }
    }
}
