using Microsoft.AspNetCore.Authorization;
using WebGallery.Infrastructure.Security.AuthorizationRequirements;

namespace WebGallery.Infrastructure.Security.Handlers
{
    public class PermissionRequirementsHandler
        : AuthorizationHandler<PermissionRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            throw new NotImplementedException();
        }
    }
}
