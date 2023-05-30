using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Application.WorkStatusEntity
{
    public class WorkStatusDto
    {
        public int Id { get; set; }
        public string Code { get; protected set; } = string.Empty;
        public IEnumerable<Guid> ComingsIds { get; set; } = new List<Guid>();
    }
}
