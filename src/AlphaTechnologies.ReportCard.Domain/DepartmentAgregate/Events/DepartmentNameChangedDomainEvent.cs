using AlphaTechnologies.ReportCard.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Domain.DepartmentAgregate.Events
{
    public class DepartmentNameChangedDomainEvent : DomainEvent
    {
        public int DepartmentId { get; }
        public string NewName { get; }

        public DepartmentNameChangedDomainEvent(int departmentId, string newName)
        {
            DepartmentId = departmentId;
            NewName = newName ?? throw new ArgumentNullException(nameof(newName));
        }
    }
}
