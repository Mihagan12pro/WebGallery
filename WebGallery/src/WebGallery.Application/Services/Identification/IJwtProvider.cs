using WebGallery.Domain.Users;


namespace WebGallery.Application.Services.Identification
{
    public interface IJwtProvider
    {
        string GenerateToken(User user);

        string SecretKey { get; }

        int ExpiredHours { get; }
    }
}