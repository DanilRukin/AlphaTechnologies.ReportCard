using AlphaTechnologies.ReportCard.Domain.EmployeeAgregate;
using AlphaTechnologies.ReportCard.Domain.WorkStatusEntity;
using AlphaTechnologies.ReportCard.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Domain.ComingEntity
{
    public class Coming : EntityBase<Guid>
    {
        public DateOnly Date { get; protected set; }
        public int EmployeeId { get; protected set; }
        public int WorkStatusId { get; protected set; }
        protected Coming() { }
        public Coming(DateOnly date) 
        {
            Id = Guid.NewGuid();
            if (date > DateOnly.FromDateTime(DateTime.Today))
                throw new ArgumentException($"Date: '{date}' can not be more than current date: '{DateTime.Today}'");
            Date = date;
        }

        internal void ChangeEmployee(Employee employee)
        {
            EmployeeId = employee.Id;
        }

        internal void ChangeWorkStatus(WorkStatus status)
        {
            WorkStatusId = status.Id;
        }
    }
}
