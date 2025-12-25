using System.ComponentModel.DataAnnotations;

namespace WebGallery.Domain.Users.Roles
{
    public class Role
    {
        public int Id { get; set; }

        [Required()]
        public string? Title { get; set; }

        public ICollection<User> Users { get; set; } = [];
    }
}
