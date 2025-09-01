using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkFlow.Vacation.Core.Entities;
using WorkFlow.Vacation.Core.Enums;

namespace WorkFlow.Vacation.Core.Interfaces
{
    public interface IVacationRequestRepository
    {
        Task<VacationRequestEntity?> GetByIdAsync(int id);
        Task<IEnumerable<VacationRequestEntity>> GetAllAsync(int? CollaboratorId = null, VacationRequestStatusEnum status = VacationRequestStatusEnum.None, DateOnly? startDate = null, DateOnly? endDate = null, int page = 1, int pageSize = 10);
        Task AddAsync(VacationRequestEntity vacationRequest);
        Task UpdateAsync(VacationRequestEntity vacationRequest);
        Task DeleteAsync(VacationRequestEntity  vacationRequest);
        Task<bool> HasOverlapAsync(DateOnly startDate, DateOnly endDate);


    }
}
