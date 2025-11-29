using FluentValidation;
using WebGallery.Contracts.Comments;

namespace WebGallery.Application.Comments;

public class CreateCommentValidator : AbstractValidator<CreateCommentDto>
{
    public CreateCommentValidator()
    {
        RuleFor(com => com.Body).NotEmpty().WithMessage("The Body field is required!");

        RuleFor(com => com.UserId).NotEmpty().WithMessage("The UserId field is required!");

        RuleFor(com => com.EntityId).NotEmpty().WithMessage("The EntityId field is required!");
    }
}