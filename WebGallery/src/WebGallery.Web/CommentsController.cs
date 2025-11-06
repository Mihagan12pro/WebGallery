using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebGallery.Web
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        [HttpGet]
        public void Comments()
        {

        }
    }
}
