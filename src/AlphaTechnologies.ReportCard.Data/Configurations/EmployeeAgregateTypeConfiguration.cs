using AlphaTechnologies.ReportCard.Domain.ComingEntity;
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
    public class EmployeeAgregateTypeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable(DataConstants.EMPLOYEES_TABLE_NAME);

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.OwnsOne(e => e.PersonalData, pd =>
            {
                pd.Property(p => p.FirstName).HasColumnName(nameof(PersonalData.FirstName));
                pd.Property(p => p.LastName).HasColumnName(nameof(PersonalData.LastName));
                pd.Property(p => p.Patronymic).HasColumnName(nameof(PersonalData.Patronymic));
            });
            builder.OwnsOne(e => e.ServiceNumber, sn => 
            {
                sn.Property(s => s.Value).HasColumnName(nameof(ServiceNumber)); 
            });
            builder.OwnsOne(e => e.Address, a =>
            {
                a.Ignore(ad => ad.Country)
                .Ignore(ad => ad.City)
                .Ignore(ad => ad.Region)
                .Ignore(ad => ad.Street)
                .Ignore(ad => ad.HouseNumber);

                a.Property(ad => ad.Value)
                .HasColumnName(DataConstants.COLUMN_NAME_FOR_VALUE_PROPERTY_OF_ADDRESS_TYPE);
            });

            builder.Ignore(e => e.Positions);
            builder.Ignore(e => e.Comings);

            builder.HasMany<Position>(DataConstants.EMPLOYEES_POSITIONS)
                .WithMany(DataConstants.POSITIONS_EMPLOYEES)
                .UsingEntity(
                    DataConstants.EMPLOYEE_POSITION_TABLE_NAME,
                    left => left.HasOne(typeof(Employee)).WithMany()
                    .HasForeignKey("id_employee").OnDelete(DeleteBehavior.Cascade),
                    right => right.HasOne(typeof(Position)).WithMany()
                    .HasForeignKey("id_position").OnDelete(DeleteBehavior.Cascade)
                );
            builder.Navigation(DataConstants.EMPLOYEES_POSITIONS)
                .UsePropertyAccessMode(PropertyAccessMode.Field);

            builder.HasMany<Coming>(DataConstants.EMPLOYEE_COMINGS)
                .WithOne()
                .HasForeignKey(c => c.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
