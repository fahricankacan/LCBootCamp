using FluentValidation;

namespace Week2.Application.Features.Commands.CategoryCommands.UpdateCategory
{
    public class UpdateCategoryCommandValidator :AbstractValidator<UpdateCategoryCommandRequest> {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Name must be less than 50 characters");
            RuleFor(x => x.Description).MaximumLength(200).WithMessage("Description must be less than 200 characters");
        }
    }

}
