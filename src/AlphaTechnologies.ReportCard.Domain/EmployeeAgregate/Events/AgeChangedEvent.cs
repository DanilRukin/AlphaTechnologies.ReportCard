using AlphaTechnologies.ReportCard.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Domain.EmployeeAgregate.Events
{
    public class AgeChangedEvent : DomainEvent
    {
        public int EmployeeId { get; }
        public int NewAge { get; }

        public AgeChangedEvent(int employeeId, int newAge)
        {
            EmployeeId = employeeId;
            NewAge = newAge;
        }
    }
}
