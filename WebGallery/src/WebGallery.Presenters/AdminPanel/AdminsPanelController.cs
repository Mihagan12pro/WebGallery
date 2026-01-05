using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebGallery.Contracts.AdminPanel;
using WebGallery.Domain.Users.Permissions;
using WebGallery.Domain.Users.Roles;

namespace WebGallery.Presenters.AdminPanel
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = Roles.Admin)]

    public class AdminsPanelController : ControllerBase
    {
        [HttpPost("block/")]
        [Authorize(Policy = Permissions.BlockUser)]
        public async Task<IActionResult> Block([FromBody] BlockUserDto request, CancellationToken cancellationToken)
        {
            return Ok();
        }

        [HttpPost("unblock/")]
        [Authorize(Policy = Permissions.UnBlockUser)]
        public async Task<IActionResult> UnBlock([FromBody] Guid UserId, CancellationToken cancellationToken)
        {
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> All(CancellationToken cancellationToken)
        {
            return Ok();
        }
    }
}
