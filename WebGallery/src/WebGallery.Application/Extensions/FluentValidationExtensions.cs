using FluentValidation;
using FluentValidation.Results;
using Shared.Errors;

namespace WebGallery.Application.Extensions
{
    public static class FluentValidationExtensions
    {
        public static Failure ToErrors(this ValidationResult validationResult)
        {
            return validationResult.Errors.Select(e => Error.Validation(
                e.ErrorCode,
                e.ErrorMessage,
                e.PropertyName
            )).ToArray();
        }
    }
}
