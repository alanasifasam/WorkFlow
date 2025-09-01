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
    public class VacationRequestMap : IEntityTypeConfiguration<VacationRequestEntity>
    {
        public void Configure(EntityTypeBuilder<VacationRequestEntity> builder)
        {
            builder.ToTable("VacationRequests");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.StartDate).IsRequired();
            builder.Property(x => x.EndDate).IsRequired();
            builder.Property(x => x.Notes).HasMaxLength(500);
            builder.HasOne(x => x.Collaborator).WithMany(x => x.VacationRequests).HasForeignKey(x => x.CollaboratorId);
        }
    }
}
