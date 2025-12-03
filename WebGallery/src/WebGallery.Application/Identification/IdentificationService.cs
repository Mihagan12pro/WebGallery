using CSharpFunctionalExtensions;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Shared.Errors;
using WebGallery.Application.Extensions;
using WebGallery.Contracts.Identification;

namespace WebGallery.Application.Identification
{
    internal class IdentificationService : IIdentificationService
    {
        private readonly IIdentificationRepository _identificationRepository;
        private readonly ILogger<IdentificationService> _logger;
        private readonly IValidator<LoginDto> _loginValidator;
        private readonly IValidator<SignInDto> _signInValidator;

        public async Task<Result<string, Failure>> Login(LoginDto request, CancellationToken cancellationToken)
        {
            var validationResult = await _loginValidator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                return validationResult.ToErrors();
            }

            throw new NotImplementedException();
        }

        public async Task<Result<string, Failure>> Register(SignInDto request, CancellationToken cancellationToken)
        {
            var validationResult = await _signInValidator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                return validationResult.ToErrors();
            }

            throw new NotImplementedException();
        }

        public IdentificationService(
            IIdentificationRepository identificationRepository,
            ILogger<IdentificationService> logger,
            IValidator<LoginDto> loginValidator,
            IValidator<SignInDto> signInValidator)
        {
            _identificationRepository = identificationRepository;

            _logger = logger;

            _loginValidator = loginValidator;

            _signInValidator = signInValidator;
        }
    }
}
