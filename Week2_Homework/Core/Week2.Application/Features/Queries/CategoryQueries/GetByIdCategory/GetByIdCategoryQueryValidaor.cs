using FluentValidation;

namespace Week2.Application.Features.Queries.CategoryQueries.GetByIdCategory
{
    public class GetByIdCategoryQueryValidaor : AbstractValidator<GetByIdCategoryQueryRequest>
    {
        public GetByIdCategoryQueryValidaor()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
        }
    }
}
