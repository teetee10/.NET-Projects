using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DentalManagementSystem.Application.Features.DentalOffices.Commands.CreateDentalOffice
{
    public class CreateDentalOfficeCommandValidator : AbstractValidator<CreateDentalOfficeCommand>
    {
        public CreateDentalOfficeCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("The name is required")
                .MaximumLength(100).WithMessage("The name must not exceed 100 characters");
        }
    }
}
