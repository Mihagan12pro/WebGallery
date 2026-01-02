using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebGallery.Domain.Users;
using WebGallery.Domain.Users.PivotTables;
using WebGallery.Domain.Users.Roles;

namespace WebGallery.Infrastracture.PostgreSql.EntityConfigurations.Users
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Email).
                HasColumnType("citext");

            builder.Property(u => u.UserName).
             HasColumnType("citext");

            builder.HasMany(u => u.Roles)
                .WithMany(u => u.Users)
                .UsingEntity<UserRole>(
                    ur => ur.HasOne<Role>().WithMany().HasForeignKey(r => r.RoleId),
                    ur => ur.HasOne<User>().WithMany().HasForeignKey(u => u.UserId));
        }
    }
}
