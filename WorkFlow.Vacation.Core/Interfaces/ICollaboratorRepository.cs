using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkFlow.Vacation.Core.Entities;

namespace WorkFlow.Vacation.Core.Interfaces
{
    public interface ICollaboratorRepository
    {
        Task AddAsync(CollaboratorEntity collaboractor);
        Task<CollaboratorEntity?> GetByIdAsync(int id);
        Task<IEnumerable<CollaboratorEntity>> GetAllAsync(string? name = null, string? email = null, int page = 1, int pageSize = 10);
        Task<CollaboratorEntity> UpdateAsync(CollaboratorEntity collaborator);
        Task<bool> DeleteAsync(int id);
    }
}
