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

        [Fact]
        public void ChekIn_CheckEmployee_EmployeeWasCheked()
        {
            Employee employee = GetNextDefaultEmployee();
            DateOnly date = DateOnly.FromDateTime(DateTime.Today);
            var status = GetNextDefaultWorkStatus();
            var coming = employee.CheckIn(date, status);

            Assert.NotEmpty(status.Comings);
            Assert.Contains(coming, status.Comings);

            Assert.Equal(status.Id, coming.WorkStatusId);
            Assert.Equal(employee.Id, coming.EmployeeId);
            Assert.NotEmpty(employee.Comings);
            Assert.Contains(coming, employee.Comings);
        }

        [Fact]
        public void CheckIn_EmployeeWasAlreadyCheked_ThrowsExceptionWithMessage()
        {
            Employee employee = GetNextDefaultEmployee();
            DateOnly date = DateOnly.FromDateTime(DateTime.Today);
            var status = GetNextDefaultWorkStatus();
            var anotherStatus = _workStatusFactory.Create("Status");
            string message = $"Employee with id: {employee.Id} is already cheked in";
            var coming = employee.CheckIn(date, status);

            InvalidOperationException exc = Assert.Throws<InvalidOperationException>(() => employee.CheckIn(date, anotherStatus));
            Assert.NotNull(exc);
            Assert.Equal(message, exc.Message);
        }

        [Fact]
        public void ChangeWorkStatus_EmployeeWasNotChekedYet_ThrowsExceptionWithMessage()
        {
            Employee employee = GetNextDefaultEmployee();
            DateOnly date = DateOnly.FromDateTime(DateTime.Today);
            var status = GetNextDefaultWorkStatus();
            var anotherStatus = _workStatusFactory.Create("Status");
            string message = $"Employee was not cheked yet. Check it first";

            InvalidOperationException exc = Assert.Throws<InvalidOperationException>(() => employee.ChangeWorkStatus(date, status, anotherStatus));
            Assert.NotNull(exc);
            Assert.Equal(message, exc.Message);
        }

        [Fact]
        public void ChangeWorkStatus_EmployeeWasNotChekedOnThisDateButWasChekedToday_ThrowsExceptionWithMessage()
        {
            Employee employee = GetNextDefaultEmployee();
            DateOnly date = DateOnly.FromDateTime(DateTime.Today);
            var status = GetNextDefaultWorkStatus();
            var anotherStatus = _workStatusFactory.Create("Status");
            string message = $"Employee was not cheked yet. Check it first";
            employee.CheckIn(date, status);

            date = date.AddDays(1);
            InvalidOperationException exc = Assert.Throws<InvalidOperationException>(() => employee.ChangeWorkStatus(date, status, anotherStatus));
            Assert.NotNull(exc);
            Assert.Equal(message, exc.Message);
        }

        [Fact]
        public void ChangeWorkStatus_EmployeeWasCheked_WorkStatusChanged()
        {
            Employee employee = GetNextDefaultEmployee();
            DateOnly date = DateOnly.FromDateTime(DateTime.Today);
            var status = GetNextDefaultWorkStatus();
            var anotherStatus = _workStatusFactory.Create("Status");
            var coming = employee.CheckIn(date, status);

            employee.ChangeWorkStatus(coming.Date,status, anotherStatus);

            Assert.DoesNotContain(coming, status.Comings);
            Assert.Contains(coming, anotherStatus.Comings);
            Assert.Equal(anotherStatus.Id, coming.WorkStatusId);
            Assert.NotEqual(status.Id, coming.WorkStatusId);
        }
    }
}
