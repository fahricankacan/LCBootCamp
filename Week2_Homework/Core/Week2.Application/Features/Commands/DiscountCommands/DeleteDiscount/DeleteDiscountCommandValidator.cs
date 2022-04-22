using FluentValidation;

namespace Week2.Application.Features.Commands.DiscountCommands.DeleteDiscount
{

    public partial class DeleteDiscountCommandHandler
    {
        public class DeleteDiscountCommandValidator : AbstractValidator<DeleteDiscountCommandRequest>
        {
            public DeleteDiscountCommandValidator()
            {
                RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
            }
        }
    }
}
