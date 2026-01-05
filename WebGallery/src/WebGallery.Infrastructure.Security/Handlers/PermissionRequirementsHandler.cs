using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;
using WebGallery.Application.Services.Identification;
using WebGallery.Domain.Users.Permissions;
using WebGallery.Infrastructure.Security.AuthorizationRequirements;

namespace WebGallery.Infrastructure.Security.Handlers
{
    public class PermissionRequirementsHandler
        : AuthorizationHandler<PermissionRequirement>
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        protected override async Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            PermissionRequirement requirement)
        {
            var userIdClaim = context.User.Claims.FirstOrDefault(c => c.Type == "userId");

            using (var scope = _serviceScopeFactory.CreateScope())
            {
                IIdentificationRepository repository = scope.ServiceProvider
                    .GetRequiredService<IIdentificationRepository>();

                Guid userId = Guid.Parse(userIdClaim!.Value);

                var result = await repository.GetPermissionByUserId(userId);

                if (result.IsSuccess)
                {
                    var permissions = result.Value;

                    var permission = permissions
                        .FirstOrDefault(p => p.Name == requirement.Permission);

                    if (permission != null)
                    {
                        context.Succeed(requirement);
                    }
                }
            }
        }

        public PermissionRequirementsHandler(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }
    }
}
