using FluentValidation;

namespace Week1_Homework.Application.TshirtOperations.Commands.Delete
{
    public class DeleteTshirtCommandValidator:AbstractValidator<DeleteTshirtCommand>
    {
        public DeleteTshirtCommandValidator(int id)
        {
            RuleFor(c => id).NotNull().GreaterThan(0);
        }
    }
}
