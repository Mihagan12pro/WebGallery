using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebGallery.Application.Services.Identification;
using WebGallery.Contracts.Identification;

namespace WebGallery.Presenters.Identification
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IIdentificationService _identificationService;

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

        public AuthController(IIdentificationService identificationService)
        {
            _identificationService = identificationService;
        }
    }
}
