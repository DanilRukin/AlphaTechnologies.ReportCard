using AlphaTechnologies.ReportCard.Domain.ComingEntity;
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
    public class WorkStatusEntityTypeConfiguration : IEntityTypeConfiguration<WorkStatus>
    {
        public void Configure(EntityTypeBuilder<WorkStatus> builder)
        {
            builder.ToTable(DataConstants.WORK_STATUS_TABLE_NAME);

            builder.HasKey(w => w.Id);
            builder.Property(w => w.Id).ValueGeneratedOnAdd();

            builder.Ignore(w => w.Comings);
            builder.Ignore(w => w.DomainEvents);

            builder.HasMany<Coming>(DataConstants.WORK_STATUS_COMINGS)
                .WithOne()
                .HasForeignKey(c => c.WorkStatusId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Navigation(DataConstants.WORK_STATUS_COMINGS)
                .UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
