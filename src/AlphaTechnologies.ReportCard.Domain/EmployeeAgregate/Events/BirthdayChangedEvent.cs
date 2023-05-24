using AlphaTechnologies.ReportCard.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Domain.EmployeeAgregate.Events
{
    public class BirthdayChangedEvent : DomainEvent
    {
        public int EmployeeId { get; }
        public DateOnly Date { get; }

        public BirthdayChangedEvent(int employeeId, DateOnly date)
        {
            EmployeeId = employeeId;
            Date = date;
        }
    }
}
