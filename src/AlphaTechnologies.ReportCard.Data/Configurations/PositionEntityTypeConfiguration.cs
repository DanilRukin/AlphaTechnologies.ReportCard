using AlphaTechnologies.ReportCard.Domain.EmployeeAgregate;
using AlphaTechnologies.ReportCard.Domain.PositionEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Data.Configurations
{
    public class PositionEntityTypeConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.ToTable(DataConstants.POSITIONS_TABLE_NAME);

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Ignore(p => p.DomainEvents);
            builder.Ignore(p => p.Emloyees);

            builder.HasMany<Employee>(DataConstants.POSITIONS_EMPLOYEES)
                .WithMany(DataConstants.EMPLOYEES_POSITIONS)
                .UsingEntity(
                    DataConstants.EMPLOYEE_POSITION_TABLE_NAME,
                    left => left.HasOne(typeof(Employee)).WithMany()
                    .HasForeignKey("id_employee").OnDelete(DeleteBehavior.Cascade),
                    right => right.HasOne(typeof(Position)).WithMany()
                    .HasForeignKey("id_position").OnDelete(DeleteBehavior.Cascade)
                );
            builder.Navigation(DataConstants.POSITIONS_EMPLOYEES)
                .UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
