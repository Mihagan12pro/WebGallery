using System.ComponentModel.DataAnnotations;
using WebGallery.Domain.Users.Permissions;

namespace WebGallery.Domain.Users.Roles
{
    public class Role
    {
        public int Id { get; set; }

        [Required()]
        public string Name { get; set; } = string.Empty;

        public ICollection<User> Users { get; set; } = [];

        public ICollection<Permission> Permissions { get; set; } = [];
    }
}
