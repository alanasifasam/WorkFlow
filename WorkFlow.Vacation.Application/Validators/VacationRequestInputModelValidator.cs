using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkFlow.Vacation.Application.Models.InputModels;

namespace WorkFlow.Vacation.Application.Validators
{
    internal class VacationRequestInputModelValidator : AbstractValidator<VacationRequestInputModel>
    {
        public VacationRequestInputModelValidator()
        {
            RuleFor(x => x.CollaboratorId)
           .GreaterThan(0)
           .WithMessage("CollaboratorId must be greater than 0.");

            RuleFor(x => x.StartDate)
                .LessThanOrEqualTo(x => x.EndDate)
                .WithMessage("StartDate must be before or equal to EndDate.");

        }
    }
}
