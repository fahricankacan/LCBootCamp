using FluentValidation;

namespace Week2.Application.Features.Commands.CategoryCommands.UpdateCategory
{
    public class UpdateCategoryCommandValidator :AbstractValidator<UpdateCategoryCommandRequest> {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        }
    }

}
