using AlphaTechnologies.ReportCard.Domain.DepartmentAgregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.IntegrationTests.Data
{
    public class DataAccessTests : EfCoreBaseFixture
    {
        [Fact]
        public void AddDepartments_DepartmentShouldBeAdded()
        {
            var context = GetClearContext();
            context.Database.EnsureCreated();
            Department department = new Department("name");
            Assert.True(department.Id == 0);

            context.Add(department);
            context.SaveChanges();

            Department result = context.Departments.First();
            Assert.NotNull(result);
            Assert.True(result.Id > 0);
        }
    }
}
