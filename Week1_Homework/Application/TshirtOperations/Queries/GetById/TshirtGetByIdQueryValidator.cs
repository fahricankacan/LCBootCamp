using FluentValidation;

namespace Week1_Homework.Application.TshirtOperations.Queries.GetById
{
    public class TshirtGetByIdQueryValidator: AbstractValidator<TshirtGetByIdQuery>
    {
        public TshirtGetByIdQueryValidator(int id)
        {
            RuleFor(c => id).NotNull().GreaterThan(0);
        }
    }
}
