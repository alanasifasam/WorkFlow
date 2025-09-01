using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkFlow.Vacation.Core.Entities;
using WorkFlow.Vacation.Core.Enums;
using WorkFlow.Vacation.Core.Interfaces;
using WorkFlow.Vacation.Infrastructure.Persistence;

namespace WorkFlow.Vacation.Infrastructure.Repositories
{
    public class VacationRequestRepository : IVacationRequestRepository
    {
        private readonly Context _context;
        public VacationRequestRepository(Context context)
        {
            _context = context;
        }
        public async Task<VacationRequestEntity?> GetByIdAsync(int id)
        {
            return await _context.VacationRequests.FindAsync(id);
        }


        public async Task<IEnumerable<VacationRequestEntity>> GetAllAsync(int? CollaboratorId = null, VacationRequestStatusEnum status = VacationRequestStatusEnum.None, DateOnly? startDate = null,DateOnly? endDate = null,int page = 1,int pageSize = 10)
        {
            var query = _context.Set<VacationRequestEntity>().AsQueryable();

            if (CollaboratorId.HasValue)
                query = query.Where(x => x.CollaboratorId == CollaboratorId.Value);

            if (status != VacationRequestStatusEnum.None)
                query = query.Where(x => x.Status == status);

            if (startDate.HasValue)
                query = query.Where(x => x.StartDate >= startDate.Value);

            if (endDate.HasValue)
                query = query.Where(x => x.EndDate <= endDate.Value);

            return await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task AddAsync(VacationRequestEntity vacationRequest)
        {
            await _context.VacationRequests.AddAsync(vacationRequest);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(VacationRequestEntity vacationRequest)
        {
            _context.VacationRequests.Update(vacationRequest);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(VacationRequestEntity vacationRequest)
        {
              _context.VacationRequests.Remove(vacationRequest);
              await _context.SaveChangesAsync();
        }

        public async Task<bool> HasOverlapAsync(DateOnly startDate, DateOnly endDate)
        {
            var query = _context.VacationRequests.AsQueryable();

         
            return await query
                .Where(v => v.Status == VacationRequestStatusEnum.Approved
                         || v.Status == VacationRequestStatusEnum.Pending)
                .AnyAsync(v => !(endDate < v.StartDate || startDate > v.EndDate));
        }



    }
}
