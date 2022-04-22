using FluentValidation;

namespace Week2.Application.Features.Queries.DiscountQueries.GetByIdDiscount
{
    public class GetByIdDiscountQueryHandlerValidator : AbstractValidator<GetByIdDiscountQueryRequest>
    {
        public GetByIdDiscountQueryHandlerValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
        }
    }
}
