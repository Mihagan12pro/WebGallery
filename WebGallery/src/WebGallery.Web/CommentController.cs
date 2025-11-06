using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebGallery.Web
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Comments([FromBody] string body)
        {
            return Ok(body);
        }
    }
}
