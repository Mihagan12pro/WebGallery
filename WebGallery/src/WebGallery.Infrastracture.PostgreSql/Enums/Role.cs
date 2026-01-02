using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGallery.Infrastracture.PostgreSql.Enums
{
    public enum Role
    {
        /// <summary>
        /// Admin role
        /// </summary>
        Admin = 1,

        /// <summary>
        /// Simple user role
        /// </summary>
        User = 2,
    }
}
