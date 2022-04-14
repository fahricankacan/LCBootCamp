using FluentValidation;

namespace Week1_Homework.Application.TshirtOperations.Queries.Search
{
    public class TshirtSearchQueryValidator:AbstractValidator<TshirtSearchViewModel>
    {
        public TshirtSearchQueryValidator()
        {

            RuleFor(c => c.Price).GreaterThanOrEqualTo(0);
            RuleFor(c => c.Title).MinimumLength(3);
            RuleFor(c => c.Color).IsInEnum();
            RuleFor(c => c.Category).IsInEnum();
            RuleFor(c => c.Size).IsInEnum();
        }
    }
}
