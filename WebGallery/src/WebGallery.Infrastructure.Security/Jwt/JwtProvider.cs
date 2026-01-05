using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WebGallery.Application.Services.Identification;
using WebGallery.Domain.Users;

namespace WebGallery.Infrastructure.Security.Jwt
{
    public class JwtProvider : IJwtProvider
    {
        private readonly JwtOptions _options;

        public string SecretKey
            => _options.SecretKey;

        public int ExpiredHours
            => _options.ExpiredHours;

        public string GenerateToken(User user)
        {
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_options.SecretKey));

            SigningCredentials signingCredentials = new SigningCredentials(
                    securityKey,
                    SecurityAlgorithms.HmacSha256);

            Claim[] claims = { new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()) };

            JwtSecurityToken token =
                new JwtSecurityToken(
                    claims: claims,
                    signingCredentials: signingCredentials,
                    expires: DateTime.UtcNow.AddHours(_options.ExpiredHours));

            string tokenString =
                new JwtSecurityTokenHandler().WriteToken(token);

            return tokenString;
        }

        public JwtProvider(IOptions<JwtOptions> options)
        {
            _options = options.Value;
        }
    }
}
