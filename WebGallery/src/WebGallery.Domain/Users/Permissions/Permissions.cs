namespace WebGallery.Domain.Users.Permissions
{
    public static class Permissions
    {
        public static string Read
            => nameof(Read);

        public static string Edit
            => nameof(Edit);

        public static string Delete
            => nameof(Delete);

        public static string Create
            => nameof(Create);

        public static string BlockUser
            => nameof(BlockUser);

        public static string UnBlockUser
            => nameof(UnBlockUser);
    }
}
