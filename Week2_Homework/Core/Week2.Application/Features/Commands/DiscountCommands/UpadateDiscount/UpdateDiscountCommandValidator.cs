﻿using FluentValidation;

namespace Week2.Application.Features.Commands.DiscountCommands.UpadateDiscount
{
    public class UpdateDiscountCommandValidator : AbstractValidator<UpdateDiscountCommandRequest> {
        public UpdateDiscountCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
            RuleFor(x => x.DiscountPercent).NotEmpty().WithMessage("DiscountPercent is required");
            //RuleFor(x => x.IsActive).NotEmpty().WithMessage("IsActive is required");
        }
    }

}
