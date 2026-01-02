using Microsoft.AspNetCore.Authorization;

namespace WebGallery.Infrastructure.Security.AuthorizationRequirements
{
    public class PermissionRequirement : IAuthorizationRequirement
    {
        public string Permission { get; }

        public PermissionRequirement(string permission)
        {
            Permission = permission;
        }
    }
}
