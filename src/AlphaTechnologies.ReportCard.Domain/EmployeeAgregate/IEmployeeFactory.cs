using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Domain.EmployeeAgregate
{
    public interface IEmployeeFactory
    {
        Employee Create(DateOnly birthday, Address address, string serviceNumber, string firstName, string lastName,
            string patronymic = "");
    }
}
