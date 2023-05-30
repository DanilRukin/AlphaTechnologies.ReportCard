using AlphaTechnologies.ReportCard.SharedKernel.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Application.WorkStatusEntity.Queries
{
    public class GetWorkStatusByIdQuery : IRequest<Result<WorkStatusDto>>
    {
        public WorkStatusIncludeOptions Options { get; }

        public GetWorkStatusByIdQuery(WorkStatusIncludeOptions options)
        {
            Options = options ?? throw new ArgumentNullException(nameof(options));
        }
    }
}
