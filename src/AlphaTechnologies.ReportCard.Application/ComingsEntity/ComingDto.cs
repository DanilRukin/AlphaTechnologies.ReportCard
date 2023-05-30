using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Application.ComingsEntity
{
    public class ComingDto
    {
        public Guid Id { get; set; } = Guid.Empty;
        public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public int EmployeeId { get; set; }
        public int WorkStatusId { get; set; }
    }
}
