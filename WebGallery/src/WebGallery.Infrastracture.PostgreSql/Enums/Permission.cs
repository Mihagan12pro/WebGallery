using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGallery.Infrastracture.PostgreSql.Enums
{
    public enum Permission
    {
        /// <summary>
        /// Read comments, posts and etc
        /// </summary>
        Read = 0,

        /// <summary>
        /// Create post or comment
        /// </summary>
        Create = 1,

        /// <summary>
        /// Edit post or comment
        /// </summary>
        Edit = 2,

        /// <summary>
        /// Delete post or comment
        /// </summary>
        Delete = 3,

        /// <summary>
        /// Block user
        /// </summary>
        BlockUser = 4,

        /// <summary>
        /// Unblock user
        /// </summary>
        UnblockUser = 5,
    }
}
