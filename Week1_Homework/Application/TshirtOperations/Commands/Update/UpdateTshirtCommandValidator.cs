using FluentValidation;

namespace Week1_Homework.Application.TshirtOperations.Commands.Update
{
    public class UpdateTshirtCommandValidator:AbstractValidator<UpdateTshirtViewModel>
    {
        public UpdateTshirtCommandValidator(int id)
        {
            RuleFor(c => id).NotNull().GreaterThan(0);
            RuleFor(c => c.Price).GreaterThan(0);
            RuleFor(c => c.Title).NotNull().MinimumLength(3);
            RuleFor(c => c.Color).IsInEnum();
            RuleFor(c => c.Category).NotNull().IsInEnum();
            RuleFor(c => c.Size).NotNull().IsInEnum();
        }
    }
}
