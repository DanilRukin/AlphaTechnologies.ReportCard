using AlphaTechnologies.ReportCard.SharedKernel.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Application.ProductionCalendarEntity.Queries
{
    public class IsDateHolidayQuery : IRequest<Result<bool>>
    {
        public DateOnly Date { get; }

        public IsDateHolidayQuery(DateOnly date)
        {
            Date = date;
        }
    }
}
