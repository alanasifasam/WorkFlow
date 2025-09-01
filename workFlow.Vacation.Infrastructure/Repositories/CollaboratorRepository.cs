using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WorkFlow.Vacation.Core.Entities;
using WorkFlow.Vacation.Core.Interfaces;
using WorkFlow.Vacation.Infrastructure.Persistence;

namespace WorkFlow.Vacation.Infrastructure.Repositories
{
    public class CollaboratorRepository : ICollaboratorRepository
    {
        private readonly Context _context;
        public CollaboratorRepository(Context context)
        { 
            _context = context;
        }
        public async Task AddAsync(CollaboratorEntity collaboractor)
        {
            await _context.AddAsync(collaboractor);
            await _context.SaveChangesAsync();
            return;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var collaborator = await _context.Set<CollaboratorEntity>().FindAsync(id);
            if (collaborator == null) return false;
            _context.Set<CollaboratorEntity>().Remove(collaborator);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<CollaboratorEntity>> GetAllAsync(string? name = null,string? email = null,int page = 1,int pageSize = 10)
        {

            var query = _context.Set<CollaboratorEntity>().AsQueryable();

            if (!string.IsNullOrEmpty(name))
                query = query.Where(c => c.Name.Contains(name));

            if (!string.IsNullOrEmpty(email))
                query = query.Where(c => c.Email.Contains(email));

            query = query.Skip((page - 1) * pageSize)
                         .Take(pageSize);

            
            var result = await query.ToListAsync();
            return result;

        }

        public async Task<CollaboratorEntity?> GetByIdAsync(int id)
        {
            return await _context.Set<CollaboratorEntity>().FindAsync(id);
        }

        public async Task<CollaboratorEntity> UpdateAsync(CollaboratorEntity collaborator)
        {
            _context.Set<CollaboratorEntity>().Update(collaborator);
            await _context.SaveChangesAsync();
            return collaborator;
        }
    }
}
