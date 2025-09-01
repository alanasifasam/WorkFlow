using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkFlow.Vacation.Core.Enums;

namespace WorkFlow.Vacation.Core.Entities
{
    public class VacationRequestEntity
    {
        public int Id { get; set; }

        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }

        public string? Notes { get; set; }

        public VacationRequestStatusEnum Status { get; set; }

        public int CollaboratorId { get; set; }
        public CollaboratorEntity Collaborator { get; set; } = null!;
    }
}
