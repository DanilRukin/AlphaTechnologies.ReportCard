using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Application.EmployeeAgregate
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Patronymic { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string ServiceNumber { get; set; } = string.Empty;
        public DateOnly Birthday { get; set; }
        public bool IsRemote { get; set; } = false;
        public IEnumerable<int> PositionsIds { get; set; } = new List<int>();
        public IEnumerable<Guid> ComingDaysIds { get; set; } = new List<Guid>();
    }
}
