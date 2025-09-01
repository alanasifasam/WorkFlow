using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkFlow.Vacation.Application.Models.InputModels;

namespace WorkFlow.Vacation.Application.Validators
{
    public class FirstAccessInputModelValidator : AbstractValidator<FirstAccessInputModel>
    {
        public FirstAccessInputModelValidator()
        {
            RuleFor(e => e.UserName)
               .NotEmpty().WithMessage("UserName is required")
               .MaximumLength(50);
            RuleFor(e => e.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email format")
                .Matches(@"^[^@\s]+@gmail\.com$").WithMessage("Email must be a Gmail address");

            RuleFor(e => e.Password).NotEmpty().WithMessage("Password");
        }
    }
}
