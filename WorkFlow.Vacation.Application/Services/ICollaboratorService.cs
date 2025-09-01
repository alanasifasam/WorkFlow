using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkFlow.Vacation.Application.Models.InputModels;
using WorkFlow.Vacation.Application.Models.OutputModels;

namespace WorkFlow.Vacation.Application.Services
{
    public interface ICollaboratorService
    {
        Task CreateAsync(CollaboratorInputModel input);
        Task<CollaboratorOutputModel?> GetByIdAsync(int id);
        Task<IEnumerable<CollaboratorOutputModel>> GetAllAsync(string? name = null, string? email = null, int page = 1, int pageSize = 10);
        Task<CollaboratorOutputModel?> UpdateAsync(int id, CollaboratorInputModel input);
        Task<bool> DeleteAsync(int id);
    }
}
