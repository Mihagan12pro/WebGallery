using FluentValidation;
using WebGallery.Contracts.Comments;

namespace WebGallery.Application.Comments;

public class CreateCommentValidator : AbstractValidator<CreateCommentDto>
{
    public CreateCommentValidator()
    {
        RuleFor(com => com.Body).Length(1, 255).WithMessage("Body is required!");

        RuleFor(com => com.UserId).NotEmpty().WithMessage("UserId is required!");

        RuleFor(com => com.EntityId).NotEmpty().WithMessage("EntityId is required!");
    }
}