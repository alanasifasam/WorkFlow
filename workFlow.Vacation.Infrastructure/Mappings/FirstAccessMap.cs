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
    public class FirstAccessMap : IEntityTypeConfiguration<FirstAccessEntity>
    {
        public void Configure(EntityTypeBuilder<FirstAccessEntity> builder)
        {
            builder.HasKey(f => f.Id);
            builder.Property(f => f.UserName);
            builder.Property(f => f.Email);
            builder.Property(f => f.Password);
            builder.ToTable("FirstAccess");

        }
    }
}
