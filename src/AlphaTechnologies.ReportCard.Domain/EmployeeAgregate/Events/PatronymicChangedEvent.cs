using AlphaTechnologies.ReportCard.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Domain.EmployeeAgregate.Events
{
    public class PatronymicChangedEvent : DomainEvent
    {
        public int EmployeeId { get; }
        public string Patronymic { get; }

        public PatronymicChangedEvent(int employeeId, string patronymic)
        {
            EmployeeId = employeeId;
            Patronymic = patronymic ?? throw new ArgumentNullException(nameof(patronymic));
        }
    }
}
