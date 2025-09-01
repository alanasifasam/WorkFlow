using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkFlow.Vacation.Core.Entities;
using WorkFlow.Vacation.Core.Interfaces;
using WorkFlow.Vacation.Infrastructure.Persistence;

namespace WorkFlow.Vacation.Infrastructure.Repositories
{
    public class FirstAccessRepository : IFirstAccessRepository
    {
        private readonly Context _context;
        public FirstAccessRepository(Context context)
        {
            _context = context;
        }
        public async Task<Guid> CreatAccessAsync(FirstAccessEntity firstAccess)
        {
            await _context.FirstAccess.AddAsync(firstAccess);
            await _context.SaveChangesAsync();
            return firstAccess.Id;
        }

        public async Task<FirstAccessEntity> GetFirstAccessAsync(FirstAccessEntity entity)
        {
            var firstAccess = await _context.FirstAccess.SingleOrDefaultAsync(x => x.Email == entity.Email && x.Password == entity.Password);
            return firstAccess;
        }
    }
}
