using AlphaTechnologies.ReportCard.SharedKernel.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Application.ComingsEntity.Queries
{
    public class GetComingWithEmployeeYearAndMonthQuery : IRequest<Result<IEnumerable<ComingDto>>>
    {
        public int EmployeeId { get; }
        public int Year { get; }
        public int Month { get; }

        public GetComingWithEmployeeYearAndMonthQuery(int employeeId, int year, int month)
        {
            EmployeeId = employeeId;
            Year = year;
            Month = month;
        }
    }
}
