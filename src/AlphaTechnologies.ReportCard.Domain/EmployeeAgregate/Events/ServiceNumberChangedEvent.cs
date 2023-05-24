using AlphaTechnologies.ReportCard.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Domain.EmployeeAgregate.Events
{
    public class ServiceNumberChangedEvent : DomainEvent
    {
        public int EmployeeId { get; }
        public string ServiceNumber { get; }

        public ServiceNumberChangedEvent(int employeeId, string serviceNumber)
        {
            EmployeeId = employeeId;
            ServiceNumber = serviceNumber ?? throw new ArgumentNullException(nameof(serviceNumber));
        }
    }
}
