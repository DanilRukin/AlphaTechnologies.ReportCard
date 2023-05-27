using AlphaTechnologies.ReportCard.Domain.ComingEntity;
using AlphaTechnologies.ReportCard.Domain.EmployeeAgregate;
using AlphaTechnologies.ReportCard.Domain.PositionEntity;
using AlphaTechnologies.ReportCard.Domain.WorkStatusEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Data.Configurations
{
    public class ComingEntityTypeConfiguration : IEntityTypeConfiguration<Coming>
    {
        public void Configure(EntityTypeBuilder<Coming> builder)
        {
            builder.ToTable(DataConstants.COMINGS_TABLE_NAME);

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedNever();

            builder.Ignore(c => c.DomainEvents);

            builder.HasOne<Employee>()
                .WithMany(DataConstants.EMPLOYEE_COMINGS)
                .HasForeignKey(c => c.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<WorkStatus>()
                .WithMany(DataConstants.WORK_STATUS_COMINGS)
                .HasForeignKey(c => c.WorkStatusId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
