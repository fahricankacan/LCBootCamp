using FluentValidation;

namespace Week2.Application.Features.Commands.DiscountCommands.CreateDiscount
{
    public class CreateDiscountCommandValidator :AbstractValidator<CreateDiscountCommandRequest>
    {
        public CreateDiscountCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
            RuleFor(x => x.DiscountPercent).NotEmpty().WithMessage("DiscountPercent is required");
            RuleFor(x => x.IsActive).NotEmpty().WithMessage("IsActive is required");
        }

    }

}
