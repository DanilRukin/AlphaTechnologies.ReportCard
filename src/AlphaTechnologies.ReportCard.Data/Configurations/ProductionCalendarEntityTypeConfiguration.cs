using AlphaTechnologies.ReportCard.Domain.ProductionCalendarEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Data.Configurations
{
    public class ProductionCalendarEntityTypeConfiguration : IEntityTypeConfiguration<ProductionCalendar>
    {
        public void Configure(EntityTypeBuilder<ProductionCalendar> builder)
        {
            builder.ToTable(DataConstants.PRODUCTION_CALENDAR_TABLE_NAME);

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Ignore(p => p.DomainEvents);
            builder.Ignore(p => p.Holidays);

            builder.Property<string>(DataConstants.HOLIDAYS_LIST_NAME)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName(DataConstants.PRODUCTION_CALENDAR_HOLIDAYS_ATTRIBUTE_NAME);
        }
    }
}
