using FluentValidation;


namespace Week2.Application.Features.Queries.ProductQueries.GetByIdProduct
{

    public partial class GetByIdProductQuery
    {
        public class GetByIdProductQueryValidator : AbstractValidator<GetByIdProductQueryRequest>
        {
            public GetByIdProductQueryValidator()
            {
                RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
            }
        }
    }
}
