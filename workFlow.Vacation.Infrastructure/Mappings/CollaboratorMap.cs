using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkFlow.Vacation.Core.Entities;

namespace WorkFlow.Vacation.Infrastructure.Mappings
{
    public class CollaboratorMap : IEntityTypeConfiguration<CollaboratorEntity>
    {
        public void Configure(EntityTypeBuilder<CollaboratorEntity> builder)
        {
            builder.ToTable("Collaborators");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(100);
            builder.HasMany(x => x.VacationRequests).WithOne(x => x.Collaborator).HasForeignKey(x => x.CollaboratorId);
        }
    }
}
