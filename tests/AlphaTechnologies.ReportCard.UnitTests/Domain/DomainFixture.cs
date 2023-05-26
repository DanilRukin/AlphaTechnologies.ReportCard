using AlphaTechnologies.ReportCard.Domain.DepartmentAgregate;
using AlphaTechnologies.ReportCard.Domain.EmployeeAgregate;
using AlphaTechnologies.ReportCard.Domain.PositionEntity;
using AlphaTechnologies.ReportCard.Domain.WorkStatusEntity;
using AlphaTechnologies.ReportCard.UnitTests.Services.FakeFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AlphaTechnologies.ReportCard.UnitTests.Domain
{
    public abstract class DomainFixture
    {
        protected IEmployeeFactory _employeeFactory = new FakeEmployeeFactory();
        protected IDepartmentFactory _departmentFactory = new FakeDepartmentFactory();
        protected IPositionFactory _positionFactory = new FakePositionFactory();
        protected IWorkStatusFactory _workStatusFactory = new FakeWorkStatusFactory();
        protected virtual Employee GetNextDefaultEmployee() => _employeeFactory.Create(DateOnly.MinValue,
            new Address("Russia", "Barnaul", "Altay region", "Lenina", 15), Guid.NewGuid().ToString(),
            "Ivanov", "Ivan", "Ivanovich");

        protected virtual Department GetNextDefaultDepartment() => _departmentFactory.Create("Department");

        protected virtual Position GetNextDefaultPosition() => _positionFactory.Create(nameof(Position));

        protected virtual WorkStatus GetNextDefaultWorkStatus() => _workStatusFactory.Create(nameof(WorkStatus));
    }
}
