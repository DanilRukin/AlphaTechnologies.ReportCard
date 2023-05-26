using AlphaTechnologies.ReportCard.Domain.DepartmentAgregate;
using AlphaTechnologies.ReportCard.Domain.EmployeeAgregate;
using AlphaTechnologies.ReportCard.UnitTests.Services.FakeFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.UnitTests.Domain
{
    public class DepartmentAgregateTests
    {
        private IEmployeeFactory _employeeFactory;
        private IDepartmentFactory _departmentFactory;

        private DateTime _date;

        public DepartmentAgregateTests()
        {
            _employeeFactory = new FakeEmployeeFactory();
            _departmentFactory = new FakeDepartmentFactory();
            _date = DateTime.MinValue;
        }

        [Fact]
        public void AddEmployee_NoSuchEmployeeInDepartment_EmployeeAdded()
        {
            Department department = GetNextDefaultDepartment();
            Employee employee = GetNextDefaultEmployee();

            department.AddEmployee(employee);

            Assert.NotEmpty(department.Employees);
            Assert.Contains(employee, department.Employees);
            Assert.Equal(department.Id, employee.DepartmentId);
            Assert.True(employee.DepartmentId > 0);
        }

        [Fact]
        public void AddEmployee_SuchEmployeeIsAlreadyWorksInDepartment_ThrowsExceptionWithMessage()
        {
            Department department = GetNextDefaultDepartment();
            Employee employee = GetNextDefaultEmployee();
            string message = $"This employee (id: {employee.Id}) is already works in department" +
                $" with id: {department.Id}";
            department.AddEmployee(employee);

            var exc = Assert.Throws<InvalidOperationException>(() => department.AddEmployee(employee));
            Assert.NotNull(exc);
            Assert.Equal(message, exc.Message);
        }

        private Employee GetNextDefaultEmployee() => _employeeFactory.Create(DateOnly.FromDateTime(_date), 
            new Address("Russia", "Barnaul", "Altay region", "Lenina", 15), Guid.NewGuid().ToString(),
            "Ivanov", "Ivan", "Ivanovich");

        private Department GetNextDefaultDepartment() => _departmentFactory.Create("Department");
    }
}
