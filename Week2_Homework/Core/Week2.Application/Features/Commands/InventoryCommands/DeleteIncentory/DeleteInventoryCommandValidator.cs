using FluentValidation;

namespace Week2.Application.Features.Commands.InventoryCommands.DeleteIncentory
{
    public class DeleteInventoryCommandValidator:AbstractValidator<DeleteInventoryCommandRequest> 
    {
        public DeleteInventoryCommandValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id is required");
        }
    }
}
