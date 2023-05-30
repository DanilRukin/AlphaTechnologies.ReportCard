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
    public class DepartmentAgregateTests : DomainFixture
    {
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

        [Fact]
        public void RemoveEmployee_EmployeeWorkedInDepartment_EmployeeWasRemoved()
        {
            Department department = GetNextDefaultDepartment();
            Employee employee = GetNextDefaultEmployee();
            department.AddEmployee(employee);

            Assert.Equal(department.Id, employee.DepartmentId);
            Assert.True(employee.DepartmentId > 0);

            department.RemoveEmployee(employee);

            Assert.Empty(department.Employees);
            Assert.True(employee.DepartmentId == null);
        }

        [Fact]
        public void RemoveEmployee_NoSuchEmployeeInDepartment_ThrowsExceptionWithMessage()
        {
            Department department = GetNextDefaultDepartment();
            Employee employee = GetNextDefaultEmployee();

            department.AddEmployee(employee);

            Department department2 = GetNextDefaultDepartment();
            string message = $"Unable to remove department with id: {department2.Id} because of this employee (id: {employee.Id}) works in department with id" +
                    $"{employee.DepartmentId}";
           
            InvalidOperationException exc = Assert.Throws<InvalidOperationException>(() => department2.RemoveEmployee(employee));
            Assert.NotNull(exc);
            Assert.Equal(message, exc.Message);
        }

        [Fact]
        public void RemoveEmployee_EmployeeWasNotAddedToDepartmentBefore_ThrowsExceptionWithMessage()
        {
            Department department = GetNextDefaultDepartment();
            Employee employee = GetNextDefaultEmployee();

            string message = $"Employee (id: '{employee.Id}') is not working on any department";

            InvalidOperationException exc = Assert.Throws<InvalidOperationException>(() => department.RemoveEmployee(employee));
            Assert.NotNull(exc);
            Assert.Equal(message, exc.Message);
        }
    }
}
