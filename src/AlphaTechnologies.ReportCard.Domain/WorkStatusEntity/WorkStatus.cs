using AlphaTechnologies.ReportCard.Domain.ComingEntity;
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
        public string Code { get; protected set; } = string.Empty;
        private List<Coming> _comings = new List<Coming>();
        public IReadOnlyCollection<Coming> Comings => _comings.AsReadOnly();

        protected WorkStatus() { }

        public void ChangeName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException($"The name of work status cannot be empty or null");
            Code = name;
            AddDomainEvent(new NameChangedEvent(Id, Code));
        }

        internal void AddComing(Coming coming)
        {
            _comings ??= new List<Coming>();
            if (!_comings.Any(c => c.Id == coming.Id))
                _comings.Add(coming);
        }

        internal void RemoveComing(Coming coming) 
        {
            _comings?.Remove(coming);
        }
    }
}
