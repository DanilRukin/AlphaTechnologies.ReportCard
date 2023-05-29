using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Application.EmployeeAgregate.Queries
{
    public class EmployeeIncludeOptions
    {
        public int Id { get; set; }
        public bool IncludePositions { get; }
        public bool IncludeComings { get; }

        public EmployeeIncludeOptions(int id, bool includePositions, bool includeComings)
        {
            Id = id;
            IncludePositions = includePositions;
            IncludeComings = includeComings;
        }
    }
}
