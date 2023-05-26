using AlphaTechnologies.ReportCard.Domain.DepartmentAgregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace AlphaTechnologies.ReportCard.UnitTests.Services.FakeFactories
{
    public class FakeDepartmentFactory : IDepartmentFactory
    {
        private int _nextId = 1;
        public Department Create(string name)
        {
            Department department = new Department(name);
            PropertyInfo? property = department.GetType().GetProperty(nameof(Department.Id));
            property.SetValue(department, _nextId);
            _nextId++;
            return department;
        }
    }
}
