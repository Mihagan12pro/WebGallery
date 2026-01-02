using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebGallery.Domain.Users.PivotTables;

namespace WebGallery.Infrastracture.PostgreSql.EntityConfigurations.Users.PivotTables
{
    internal class UserRoleConfiguration
        : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(r => new { r.UserId, r.RoleId });
        }
    }
}
