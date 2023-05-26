using AlphaTechnologies.ReportCard.Domain.EmployeeAgregate;
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
        private List<Employee> _employees = new List<Employee>();
        public IReadOnlyCollection<Employee> Emloyees => _employees.AsReadOnly();

        protected Position() { }

        public Position(string name)
        {
            ChangeName(name);
        }

        public void ChangeName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Position name is null or empty");
            Name = name;
            AddDomainEvent(new NameChangedEvent(Id, Name));
        }

        internal void AddEmployee(Employee employee)
        {
            _employees ??= new List<Employee>();
            if (_employees.Any(e => e.Id == employee.Id))
                throw new InvalidOperationException($"Employee with id: {employee.Id} is already on position with id: {Id}");
            _employees.Add(employee);
        }

        internal void RemoveEmployee(Employee employee)
        {
            _employees?.Remove(employee);
        }
    }
}
