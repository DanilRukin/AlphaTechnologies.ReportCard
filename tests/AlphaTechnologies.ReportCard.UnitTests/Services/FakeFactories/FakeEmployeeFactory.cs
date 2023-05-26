using AlphaTechnologies.ReportCard.Domain.EmployeeAgregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.UnitTests.Services.FakeFactories
{
    public class FakeEmployeeFactory : IEmployeeFactory
    {
        public Employee Create(DateOnly birthday, string serviceNumber, string firstName, string lastName, string patronymic = "")
        {
            throw new NotImplementedException();
        }

        public Employee CreateEmpty()
        {
            throw new NotImplementedException();
        }
    }
}
