using AlphaTechnologies.ReportCard.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Domain.PositionEntity.Events
{
    public class NameChangedEvent : DomainEvent
    {
        public int PositionId { get; }
        public string Name { get; }

        public NameChangedEvent(int positionId, string name)
        {
            PositionId = positionId;
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}
