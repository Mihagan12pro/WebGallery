using BCrypt.Net;

namespace WebGallery.Infrastructure.Security.PasswordHasher
{
    public class PasswordHasher : IPasswordHasher
    {
        public string GenerateHash(string password)
            => BCrypt.Net.BCrypt.EnhancedHashPassword(password);
    }
}
