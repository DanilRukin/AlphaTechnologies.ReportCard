using AlphaTechnologies.ReportCard.SharedKernel.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Application.EmployeeAgregate.Queries
{
    public class GetRangeOfEmployeesQuery : IRequest<Result<IEnumerable<EmployeeDto>>>
    {
        public IEnumerable<EmployeeIncludeOptions> Options { get; set; }

        public GetRangeOfEmployeesQuery(IEnumerable<EmployeeIncludeOptions> options)
        {
            Options = options ?? throw new ArgumentNullException(nameof(options));
        }
    }
}
