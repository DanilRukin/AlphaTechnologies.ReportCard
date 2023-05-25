using AlphaTechnologies.ReportCard.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Domain.DepartmentAgregate.Events
{
    public class EmployeeRemovedEvent : DomainEvent
    {
        public int DepartmentId { get; }
        public int EmployeeId { get; }

        public EmployeeRemovedEvent(int departmentId, int employeeId)
        {
            DepartmentId = departmentId;
            EmployeeId = employeeId;
        }
    }
}
