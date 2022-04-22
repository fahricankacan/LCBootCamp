using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.Application.Features.Commands.ProductCommands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommandRequest>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50).WithMessage("Name is required");
            RuleFor(x => x.Price).NotEmpty().GreaterThan(0).WithMessage("Price is required");
            RuleFor(x => x.InventoryId).NotEmpty().WithMessage("Inventory is required");
            RuleFor(x => x.DiscountId).NotEmpty().WithMessage("Discount is required");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Category is required");

        }
    }
}
