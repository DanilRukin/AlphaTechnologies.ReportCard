using AlphaTechnologies.ReportCard.Domain.DepartmentAgregate.Events;
using AlphaTechnologies.ReportCard.Domain.EmployeeAgregate;
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
        private List<Employee> _employees = new List<Employee>();

        public IReadOnlyCollection<Employee> Employees => _employees.AsReadOnly();
        
        public void ChangeName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("New name is null or empty");
            Name = name;
            AddDomainEvent(new DepartmentNameChangedDomainEvent(Id, Name));
        }
        protected Department() { }

        public Department(string name)
        {
            //Id = id;
            ChangeName(name);
        }

        public void AddEmployee(Employee employee)
        {
            _employees ??= new List<Employee>();
            if (_employees.Any(e => e.Id == employee.Id))
                throw new InvalidOperationException($"This employee (id: {employee.Id}) is already works in department with id: {Id}");
            _employees.Add(employee);
            employee.AddDepartment(this);
            AddDomainEvent(new EmployeeAddedEvent(Id, employee.Id));
        }

        public void RemoveEmployee(Employee employee) 
        {
            employee.RemoveDepartment(this);
            _employees?.Remove(employee);
            AddDomainEvent(new EmployeeRemovedEvent(Id, employee.Id));
        }
    }
}
