using AlphaTechnologies.ReportCard.Domain.ComingEntity;
using AlphaTechnologies.ReportCard.Domain.DepartmentAgregate;
using AlphaTechnologies.ReportCard.Domain.EmployeeAgregate;
using AlphaTechnologies.ReportCard.Domain.PositionEntity;
using AlphaTechnologies.ReportCard.Domain.ProductionCalendarEntity;
using AlphaTechnologies.ReportCard.Domain.WorkStatusEntity;
using AlphaTechnologies.ReportCard.SharedKernel;
using AlphaTechnologies.ReportCard.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Data
{
    public class AlphaTechnologiesRepordCardDbContext : DbContext, IEmployeeFactory, IDepartmentFactory, IWorkStatusFactory,
        IPositionFactory
    {
        protected IDomainEventDispatcher _dispatcher;
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<ProductionCalendar> ProductionCalendars { get; set; }
        public DbSet<WorkStatus> WorkStatuses { get; set; }
        public DbSet<Coming> Comings { get; set; }

        public AlphaTechnologiesRepordCardDbContext(IDomainEventDispatcher dispatcher,
            DbContextOptions<AlphaTechnologiesRepordCardDbContext> options) : base(options)
        {
            _dispatcher = dispatcher;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            base.ConfigureConventions(builder);
            builder.Properties<DateOnly>()
                .HaveConversion<Converters.DateOnlyConverter>();
        }

        public Position Create(string name)
        {
            throw new NotImplementedException();
        }

        public Employee Create(DateOnly birthday, Address address, string serviceNumber, string firstName, string lastName, string patronymic = "")
        {
            throw new NotImplementedException();
        }

        Department IDepartmentFactory.Create(string name)
        {
            throw new NotImplementedException();
        }

        WorkStatus IWorkStatusFactory.Create(string code)
        {
            throw new NotImplementedException();
        }

        public async Task SaveEntitiesAsync(CancellationToken cancellationToken)
        {
            var result = await base.SaveChangesAsync(cancellationToken);
            var events = ChangeTracker.Entries<IDomainObject>()
                .Select(e => e.Entity)
                .Where(e => e.DomainEvents.Any())
                .ToArray();
            await _dispatcher.DispatchAndClearEvents(events);
        }
    }
}
