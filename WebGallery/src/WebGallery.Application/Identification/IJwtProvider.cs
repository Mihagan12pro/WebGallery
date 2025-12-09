using WebGallery.Domain.Users;

namespace WebGallery.Infrastructure.Security.Jwt
{
    public interface IJwtProvider
    {
        string GenerateToken(User user);
    }
}