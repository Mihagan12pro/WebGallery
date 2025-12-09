using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGallery.Infrastructure.Security.PasswordHashers
{
    public interface IPasswordHasher
    {
        string GenerateHash(string password);

        bool Verify(string password, string hashedPassword);
    }
}
