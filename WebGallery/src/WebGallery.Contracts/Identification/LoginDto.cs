using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGallery.Contracts.Identification
{
    public record LoginDto(string UserName, string Password);
}
