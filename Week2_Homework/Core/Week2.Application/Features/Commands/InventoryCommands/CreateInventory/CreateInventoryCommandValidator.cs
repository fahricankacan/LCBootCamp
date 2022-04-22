using FluentValidation;

namespace Week2.Application.Features.Commands.InventoryCommands.CreateInventory
{
    public class CreateInventoryCommandValidator : AbstractValidator<CreateInventoryCommandRequest>
    {
        public CreateInventoryCommandValidator()
        {
            //RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Quantity).NotEmpty();
        }
    }

}
