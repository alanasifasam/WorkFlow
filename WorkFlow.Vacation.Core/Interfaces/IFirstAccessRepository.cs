using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkFlow.Vacation.Core.Entities;

namespace WorkFlow.Vacation.Core.Interfaces
{
    public interface IFirstAccessRepository
    {
        Task<Guid> CreatAccessAsync(FirstAccessEntity firstAccess);
        Task<FirstAccessEntity> GetFirstAccessAsync(FirstAccessEntity entity);
    }
}
