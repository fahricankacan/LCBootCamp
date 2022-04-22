using FluentValidation;

namespace Week2.Application.Features.Commands.ProductCommands.UpdateProduct
{
    public class UpdateProductCommandValidator: AbstractValidator<UpdateProductCommandRequest>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50).WithMessage("Name is required");
            RuleFor(x => x.Price).NotEmpty().GreaterThan(0).WithMessage("Price is required");
            RuleFor(x => x.InventoryId).NotEmpty().WithMessage("Inventory is required");
            RuleFor(x => x.DiscountId).NotEmpty().WithMessage("Discount is required");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Category is required");
        }
    }


}
