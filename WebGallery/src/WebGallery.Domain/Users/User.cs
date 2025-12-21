using System.ComponentModel.DataAnnotations;

namespace WebGallery.Domain.Users
{
    public class User
    {
        public Guid Id { get; set; }

        [Required()]
        public string? UserName { get; private set; }

        [Required()]
        public string? Email { get; private set; }

        [Required()]
        public string? PasswordHash { get; private set; }

        public static User Create(Guid id, string userName, string email, string passwordHash)
        {
            return new User(id, userName, email, passwordHash);
        }

        public static User Create(string userName, string email, string passwordHash)
        {
            return new User(userName, email, passwordHash);
        }

        private User(Guid id, string userName, string email, string passwordHash)
        {
            Id = id;
            UserName = userName;
            Email = email;
            PasswordHash = passwordHash;
        }

        private User(string userName, string email, string passwordHash)
        {
            UserName = userName;
            Email = email;
            PasswordHash = passwordHash;
        }
    }
}
