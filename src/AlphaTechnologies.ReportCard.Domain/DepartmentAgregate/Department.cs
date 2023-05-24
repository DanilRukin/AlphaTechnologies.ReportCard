using AlphaTechnologies.ReportCard.Domain.DepartmentAgregate.Events;
using AlphaTechnologies.ReportCard.SharedKernel;
using AlphaTechnologies.ReportCard.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Domain.DepartmentAgregate
{
    public class Department : EntityBase<int>, IAgregateRoot
    {
        public string Name { get; protected set; }
        
        public void ChangeName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("New name is null or empty");
            Name = name;
            AddDomainEvent(new DepartmentNameChangedDomainEvent(Id, Name));
        }
        protected Department() { }

        internal Department(int id, string name)
        {
            Id = id;
            ChangeName(name);
        }
    }
}
