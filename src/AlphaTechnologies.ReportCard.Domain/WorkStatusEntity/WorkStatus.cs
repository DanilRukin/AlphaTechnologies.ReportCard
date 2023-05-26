using AlphaTechnologies.ReportCard.Domain.WorkStatusEntity.Events;
using AlphaTechnologies.ReportCard.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Domain.WorkStatusEntity
{
    public class WorkStatus : EntityBase<int>
    {
        public string Name { get; protected set; } = string.Empty;

        protected WorkStatus() { }

        public void ChangeName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException($"The name of work status cannot be empty or null");
            Name = name;
            AddDomainEvent(new NameChangedEvent(Id, Name));
        }
    }
}
