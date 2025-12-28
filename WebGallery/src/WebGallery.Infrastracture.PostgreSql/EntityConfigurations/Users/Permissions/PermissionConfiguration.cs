using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Permission = WebGallery.Domain.Users.Permissions.Permission;

namespace WebGallery.Infrastracture.PostgreSql.EntityConfigurations.Users.Permissions
{
    internal class PermissionConfiguration
        : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.HasKey(b => b.Id);

            IEnumerable<Permission> permissions = Enum.GetValues<Enums.Permission>()
                .Select(p => new Permission
                {
                    Id = (int)p,

                    Name = p.ToString()
                });

            builder.HasData(permissions);
        }
    }
}
