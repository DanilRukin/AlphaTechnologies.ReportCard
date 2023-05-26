using AlphaTechnologies.ReportCard.Domain.EmployeeAgregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.UnitTests.Services.FakeFactories
{
    public class FakeEmployeeFactory : IEmployeeFactory
    {
        private int _nextId = 1;
        public Employee Create(DateOnly birthday, Address address, string serviceNumber, string firstName, string lastName, string patronymic = "")
        {
            Employee employee = new Employee(birthday, new ServiceNumber(serviceNumber),
                new PersonalData(firstName, lastName, patronymic), address);
            PropertyInfo? property = employee.GetType().GetProperty(nameof(Employee.Id));
            property.SetValue(employee, _nextId);
            _nextId++;
            return employee;
        }
    }
}
