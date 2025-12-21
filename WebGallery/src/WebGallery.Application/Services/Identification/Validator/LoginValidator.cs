using FluentValidation;
using WebGallery.Contracts.Identification;

namespace WebGallery.Application.Services.Identification.Validator
{
    public class LoginValidator: AbstractValidator<LoginDto>
    {
        public LoginValidator()
        {
            RuleFor(l => l.Password).NotEmpty().WithMessage("The Password is required field!");

            RuleFor(l => l.UserName).NotEmpty().WithMessage("The Login is required field!");
        }
    }
}
