using AlphaTechnologies.ReportCard.Domain.EmployeeAgregate;
using AlphaTechnologies.ReportCard.Domain.PositionEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.UnitTests.Domain
{
    public class EmployeeAgregateTests : DomainFixture
    {
        [Fact]
        public void AddPosition_EmployeeHasNotThisPosition_PositionAdded()
        {
            Employee employee = GetNextDefaultEmployee();
            Position position = GetNextDefaultPosition();

            employee.AddPosition(position);

            Assert.NotEmpty(employee.Positions);
            Assert.NotEmpty(position.Emloyees);
            Assert.Contains(employee, position.Emloyees);
            Assert.Contains(position, employee.Positions);
        }

        [Fact]
        public void AddPosition_EmployeeIsAlreadyOnThisPosition_ThrowsExceptionWithMessage()
        {
            Employee employee = GetNextDefaultEmployee();
            Position position = GetNextDefaultPosition();
            employee.AddPosition(position);
            string message = $"Employee with id: {employee.Id} is already on position with id: {position.Id}";

            InvalidOperationException exc = Assert.Throws<InvalidOperationException>(() => employee.AddPosition(position));

            Assert.NotNull(exc);
            Assert.Equal(message, exc.Message);
        }

        [Fact]
        public void RemovePosition_EmployeeHasNoSuchPosition_ThrowsExceptionWithMessage()
        {
            Employee employee = GetNextDefaultEmployee();
            Position position = GetNextDefaultPosition();
            string message = $"Employee with id: {employee.Id} has no such position with id: {position.Id}";

            InvalidOperationException exc = Assert.Throws<InvalidOperationException>(() => employee.RemovePosition(position));

            Assert.NotNull(exc);
            Assert.Equal(message, exc.Message);
        }

        [Fact]
        public void RemovePosition_EmployeeHasThisPosition_PositionWasRemoved()
        {
            Employee employee = GetNextDefaultEmployee();
            Position position = GetNextDefaultPosition();
            employee.AddPosition(position);
            Assert.NotEmpty(employee.Positions);
            Assert.NotEmpty(position.Emloyees);
            Assert.Contains(employee, position.Emloyees);
            Assert.Contains(position, employee.Positions);

            employee.RemovePosition(position);

            Assert.Empty(employee.Positions);
            Assert.Empty(employee.Positions);
            Assert.DoesNotContain(employee, position.Emloyees);
            Assert.DoesNotContain(position, employee.Positions);
        }
    }
}
