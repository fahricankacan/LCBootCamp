using FluentValidation;

namespace Week2.Application.Features.Commands.CategoryCommands.DeleteCategory
{

    public partial class DeleteCategoryCommandHandler
    {
        public class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommandRequest>
        {
            public DeleteCategoryCommandValidator()
            {
                RuleFor(x => x.Id).NotEmpty();
            }
        }
    }
}
