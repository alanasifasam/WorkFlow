using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkFlow.Vacation.Application.Models;
using WorkFlow.Vacation.Application.Models.InputModels;
using WorkFlow.Vacation.Application.Models.OutputModels;
using WorkFlow.Vacation.Core.Enums;

namespace WorkFlow.Vacation.Application.Services
{
    public interface IVacationRequestService
    {
        Task<ServiceResponse<VacationRequestOutputModel>> CreateAsync(VacationRequestInputModel input);
        Task<IEnumerable<VacationRequestOutputModel>> GetAllAsync(int? CollaboratorId = null, VacationRequestStatusEnum status = VacationRequestStatusEnum.None, DateOnly? startDate = null, DateOnly? endDate = null, int page = 1, int pageSize = 10);
        Task<VacationRequestOutputModel> GetByIdAsync(int id);
        Task<ServiceResponse<VacationRequestOutputModel>> UpdateAsync(int id, VacationRequestInputModel input);
        Task DeleteAsync(int id);
    }
}
