using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkFlow.Vacation.Application.Models.InputModels;

namespace WorkFlow.Vacation.Application.Validators
{
    public class CollaboratorInputModelValidator : AbstractValidator<CollaboratorInputModel>
    {
        public CollaboratorInputModelValidator()
        {
            RuleFor(e => e.Name)
               .NotEmpty().WithMessage("Name is required")
               .MaximumLength(100);

            RuleFor(e => e.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email format")
                .Matches(@"^[^@\s]+@gmail\.com$").WithMessage("Email must be a Gmail address");
        }
    }
}
