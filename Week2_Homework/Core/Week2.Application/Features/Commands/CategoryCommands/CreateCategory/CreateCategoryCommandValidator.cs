using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.Application.Features.Commands.CategoryCommands.CreateCategory
{
    public class CreateCategoryCommandValidator:AbstractValidator<CreateCategoryCommandRequest>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Description).MaximumLength(500).WithMessage("Description is too long");
        }
    }
}
