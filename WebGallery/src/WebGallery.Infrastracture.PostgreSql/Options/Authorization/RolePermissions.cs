namespace WebGallery.Infrastracture.PostgreSql.Options.Authorization
{
    public class RolePermissions
    {
        public string Role { get; set; } = string.Empty;

        public string[] Permissions { get; set; } = [];
    }
}
