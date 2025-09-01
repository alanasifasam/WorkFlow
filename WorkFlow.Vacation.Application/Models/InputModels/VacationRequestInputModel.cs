using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkFlow.Vacation.Core.Enums;

namespace WorkFlow.Vacation.Application.Models.InputModels
{
    public class VacationRequestInputModel
    {
        public int CollaboratorId { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string? Notes { get; set; }
        public VacationRequestStatusEnum Status { get; set; }
    }
}
