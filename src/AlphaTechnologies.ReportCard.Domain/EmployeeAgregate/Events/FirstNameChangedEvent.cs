using AlphaTechnologies.ReportCard.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Domain.EmployeeAgregate.Events
{
    public class FirstNameChangedEvent : DomainEvent
    {
        public int EmployeeId { get; }
        public string FirstName { get; }

        public FirstNameChangedEvent(int employeeId, string firstName)
        {
            EmployeeId = employeeId;
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
        }
    }
}
