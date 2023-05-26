using AlphaTechnologies.ReportCard.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Domain.EmployeeAgregate.Events
{
    public class WorkStatusChangedEvent : DomainEvent
    {
        public int EmployeeId { get; }
        public DateOnly Date { get; }
        public string Status { get; }

        public WorkStatusChangedEvent(int employeeId, DateOnly date, string status)
        {
            EmployeeId = employeeId;
            Date = date;
            Status = status ?? throw new ArgumentNullException(nameof(status));
        }
    }
}
