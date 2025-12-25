using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebGallery.Application.Services.Identification;
using WebGallery.Contracts.Identification;
using static CSharpFunctionalExtensions.Result;

namespace WebGallery.Presenters.Identification
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IIdentificationService _identificationService;

        private readonly IConfiguration _configuration;

        [HttpPost("/login")]
        public async Task<IActionResult> Login(
            [FromBody] LoginDto request,
            CancellationToken cancellationToken)
        {
            var response = await _identificationService.Login(request, cancellationToken);

            if (response.IsFailure)
            {
                return response.Error.ToErrorResponse();
            }

            var token = response.Value;

            HttpContext.Response.Cookies.Append(_configuration.GetSection("cookie-title").ToString(), token);

            return Ok(token);
        }

        [HttpPost("/signin")]
        public async Task<IActionResult> SignIn([FromBody] SignInDto request, CancellationToken cancellationToken)
        {
            var response = await _identificationService.Register(request, cancellationToken);

            if (response.IsFailure)
            {
                return response.Error.ToErrorResponse();
            }

            return Ok(response.Value);
        }

        public AuthController(IConfiguration configuration, IIdentificationService identificationService)
        {
            _identificationService = identificationService;

            _configuration = configuration;
        }
    }
}
