using CSharpFunctionalExtensions;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Shared.Errors;
using Shared.Errors.Common;
using Shared.Errors.Enums;
using WebGallery.Application.Extensions;
using WebGallery.Application.Services.Users;
using WebGallery.Contracts.Identification;
using WebGallery.Domain.Users;

namespace WebGallery.Application.Services.Identification
{
    internal class IdentificationService : IIdentificationService
    {
        private readonly IIdentificationRepository _identificationRepository;
        private readonly IUsersRepository _usersRepository;

        private readonly ILogger<IdentificationService> _logger;

        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtProvider _jwtProvider;

        private readonly IValidator<LoginDto> _loginValidator;
        private readonly IValidator<SignInDto> _signInValidator;

        public async Task<Result<string, Failure>> Login(LoginDto request, CancellationToken cancellationToken)
        {
            var validationResult = await _loginValidator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                return validationResult.ToErrors();
            }

            var getPasswordResult = await _identificationRepository.
                GetPasswordHashAsync(request.UserName, cancellationToken);

            if (getPasswordResult.IsFailure)
                return getPasswordResult.Error;

            bool verifyResult = _passwordHasher.Verify(request.Password, getPasswordResult.Value);

            if (!verifyResult)
            {
                return new InvalidPasswordOrLoginError().Failure;
            }

            var userResult = await _usersRepository.GetUserByUserNameAsync(request.UserName, cancellationToken);

            if (userResult.IsFailure)
                return userResult.Error.ToCollection();

            var token = _jwtProvider.GenerateToken(userResult.Value);

            return token;
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
            IUsersRepository usersRepository,
            ILogger<IdentificationService> logger,
            IPasswordHasher passwordHasher,
            IJwtProvider jwtProvider,
            IValidator<LoginDto> loginValidator,
            IValidator<SignInDto> signInValidator)
        {
            _identificationRepository = identificationRepository;

            _usersRepository = usersRepository;

            _jwtProvider = jwtProvider;

            _logger = logger;

            _passwordHasher = passwordHasher;

            _loginValidator = loginValidator;

            _signInValidator = signInValidator;
        }
    }
}
