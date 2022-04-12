using FluentValidation;

namespace Week1_Homework.Application.TshirtOperations.Commands.Create
{
    public class CreateTshirtCommandValidator : AbstractValidator<CreateTshirViewModel>
    {
        public CreateTshirtCommandValidator()
        {

            RuleFor(c => c.Price).GreaterThan(0);
        }
    }
}
