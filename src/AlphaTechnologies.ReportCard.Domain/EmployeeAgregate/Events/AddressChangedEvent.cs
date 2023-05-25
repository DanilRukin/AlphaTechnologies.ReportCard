using AlphaTechnologies.ReportCard.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Domain.EmployeeAgregate.Events
{
    public class AddressChangedEvent : DomainEvent
    {
        public int EmployeeId { get; }
        public string Address { get; }

        public AddressChangedEvent(int employeeId, string address)
        {
            EmployeeId = employeeId;
            Address = address ?? throw new ArgumentNullException(nameof(address));
        }
    }
}
