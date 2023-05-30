using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Application.ProductionCalendarEntity.Queries
{
    public class IsDateHolidayQuery
    {
        public DateOnly Date { get; }

        public IsDateHolidayQuery(DateOnly date)
        {
            Date = date;
        }
    }
}
