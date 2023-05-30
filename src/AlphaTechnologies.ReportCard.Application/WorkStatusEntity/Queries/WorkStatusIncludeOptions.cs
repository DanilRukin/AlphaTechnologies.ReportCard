using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Application.WorkStatusEntity.Queries
{
    public class WorkStatusIncludeOptions
    {
        public int WorkStatusId { get; }
        public bool IncludeComings { get; }

        public WorkStatusIncludeOptions(int workStatusId, bool includeComings)
        {
            WorkStatusId = workStatusId;
            IncludeComings = includeComings;
        }
    }
}
