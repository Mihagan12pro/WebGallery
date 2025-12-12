using CSharpFunctionalExtensions;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Shared.Errors;
using Shared.Errors.Enums;
using WebGallery.Application.Extensions;
using WebGallery.Contracts.Identification;
using WebGallery.Domain.Users;

namespace WebGallery.Application.Identification
{
    internal class IdentificationService : IIdentificationService
    {
        private readonly IIdentificationRepository _identificationRepository;
        private readonly ILogger<IdentificationService> _logger;
        private readonly IPasswordHasher _passwordHasher;
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

        public async Task<Result<Guid, Failure>> Register(SignInDto request, CancellationToken cancellationToken)
        {
            var validationResult = await _signInValidator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                return validationResult.ToErrors();
            }

            string hashedPassword = _passwordHasher.GenerateHash(password: request.Password);

            User user = User.Create(
                userName: request.UserName,
                email: request.Email,
                passwordHash: hashedPassword);

            var result = await _identificationRepository.RegisterAsync(user, cancellationToken);

            return result;
        }

        public IdentificationService(
            IIdentificationRepository identificationRepository,
            ILogger<IdentificationService> logger,
            IPasswordHasher passwordHasher,
            IValidator<LoginDto> loginValidator,
            IValidator<SignInDto> signInValidator)
        {
            _identificationRepository = identificationRepository;

            _logger = logger;

            _passwordHasher = passwordHasher;

            _loginValidator = loginValidator;

            _signInValidator = signInValidator;
        }
    }
}
