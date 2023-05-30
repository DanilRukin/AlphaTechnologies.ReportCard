using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Application.PositionEntity.Queries
{
    public class PositionIncludeOptions
    {
        public int PositionId { get; set; }
        public bool IncludeEmployees { get; }

        public PositionIncludeOptions(int positionId, bool includeEmployees)
        {
            PositionId = positionId;
            IncludeEmployees = includeEmployees;
        }
    }
}
