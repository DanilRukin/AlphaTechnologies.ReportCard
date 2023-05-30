using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Application.DepartmentAgregate.Queries
{
    public class DepartmentIncludeOptions
    {
        public int DepartmentId { get; }
        public bool IncludeEmployees { get; }

        public DepartmentIncludeOptions(int departmentId, bool includeEmployees)
        {
            DepartmentId = departmentId;
            IncludeEmployees = includeEmployees;
        }
    }
}
