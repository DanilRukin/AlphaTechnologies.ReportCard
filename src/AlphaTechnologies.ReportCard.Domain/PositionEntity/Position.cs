using AlphaTechnologies.ReportCard.Domain.PositionEntity.Events;
using AlphaTechnologies.ReportCard.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Domain.PositionEntity
{
    public class Position : EntityBase<int>
    {
        public string Name { get; protected set; }

        protected Position() { }

        public Position(int id, string name)
        {
            Id = id;
            ChangeName(name);
        }

        public void ChangeName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Position name is null or empty");
            Name = name;
            AddDomainEvent(new NameChangedEvent(Id, Name));
        }
    }
}
