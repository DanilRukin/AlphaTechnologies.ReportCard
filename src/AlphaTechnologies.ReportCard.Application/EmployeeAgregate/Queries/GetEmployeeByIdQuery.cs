using AlphaTechnologies.ReportCard.SharedKernel.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Application.EmployeeAgregate.Queries
{
    public class GetEmployeeByIdQuery : IRequest<Result<EmployeeDto>>
    {
        public EmployeeIncludeOptions Options { get; }

        public GetEmployeeByIdQuery(EmployeeIncludeOptions options)
        {
            Options = options ?? throw new ArgumentNullException(nameof(options));
        }
    }
}
