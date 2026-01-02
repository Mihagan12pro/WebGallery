namespace WebGallery.Infrastracture.PostgreSql.Enums
{
    public enum Permission
    {
        /// <summary>
        /// Read comments, posts and etc
        /// </summary>
        Read = 1,

        /// <summary>
        /// Create post or comment
        /// </summary>
        Create = 2,

        /// <summary>
        /// Edit post or comment
        /// </summary>
        Edit = 3,

        /// <summary>
        /// Delete post or comment
        /// </summary>
        Delete = 4,

        /// <summary>
        /// Block user
        /// </summary>
        BlockUser = 5,

        /// <summary>
        /// Unblock user
        /// </summary>
        UnblockUser = 6,
    }
}
