using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WorkFlow.Vacation.Core.Entities;

namespace WorkFlow.Vacation.Infrastructure.Persistence
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<CollaboratorEntity> Collaborators { get; set; }
        public DbSet<VacationRequestEntity> VacationRequests { get; set; }
        public DbSet<FirstAccessEntity> FirstAccess { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
