using AlphaTechnologies.ReportCard.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Domain.WorkStatusEntity.Events
{
    public class NameChangedEvent : DomainEvent
    {
        public int WorkStatusId { get; }
        public string Name { get; }

        public NameChangedEvent(int workStatusId, string name)
        {
            WorkStatusId = workStatusId;
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}
