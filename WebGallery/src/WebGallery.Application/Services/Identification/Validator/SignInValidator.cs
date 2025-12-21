using FluentValidation;
using WebGallery.Contracts.Identification;

namespace WebGallery.Application.Services.Identification.Validator
{
    public class SignInValidator : AbstractValidator<SignInDto>
    {
        public SignInValidator()
        {
            RuleFor(si => si.Password).NotEmpty().WithMessage("The Password is required field!");

            RuleFor(si => si.UserName).NotEmpty().WithMessage("The Login is required field!");

            RuleFor(si => si.Email).NotEmpty().WithMessage("The Email is required field!").EmailAddress()
                .WithMessage("This is can not be an email address!");
        }
    }
}
