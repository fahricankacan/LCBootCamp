using FluentValidation;

namespace Week2.Application.Features.Commands.InventoryCommands.UpdateInventory
{
    public class UpdateInventoryCommandValidator : AbstractValidator<UpdateInventoryCommandRequest>
    {
        public UpdateInventoryCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
            RuleFor(x => x.Quantity).NotEmpty().WithMessage("Quantity is required");
        }
    }

}
