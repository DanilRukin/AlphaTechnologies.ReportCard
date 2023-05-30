using AlphaTechnologies.ReportCard.SharedKernel.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Application.DepartmentAgregate.Queries
{
    public class GetDepartmentByIdQuery : IRequest<Result<DepartmentDto>>
    {
        public DepartmentIncludeOptions Options { get; }

        public GetDepartmentByIdQuery(DepartmentIncludeOptions options)
        {
            Options = options ?? throw new ArgumentNullException(nameof(options));
        }
    }
}
