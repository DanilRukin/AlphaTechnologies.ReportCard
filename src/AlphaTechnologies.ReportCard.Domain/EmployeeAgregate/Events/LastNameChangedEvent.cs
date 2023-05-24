using AlphaTechnologies.ReportCard.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Domain.EmployeeAgregate.Events
{
    public class LastNameChangedEvent : DomainEvent
    {
        public int EmployeeId { get; }
        public string LastName { get; }

        public LastNameChangedEvent(int employeeId, string lastName)
        {
            EmployeeId = employeeId;
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
        }
    }
}
