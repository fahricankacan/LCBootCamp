using FluentValidation;

namespace Week2.Application.Features.Queries.InventoryQueries.GetByIdInventory
{
    public class GetByIdInventoryQueryValidator : AbstractValidator<GetByIdInventoryQueryRequest>
    {
        public GetByIdInventoryQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
        }
    }
}
