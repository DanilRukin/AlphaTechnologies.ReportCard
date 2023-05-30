using AlphaTechnologies.ReportCard.SharedKernel.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Application.WorkStatusEntity.Queries
{
    public class GetRangeOfWorkStatusesQuery : IRequest<Result<IEnumerable<WorkStatusDto>>>
    {
        public IEnumerable<WorkStatusIncludeOptions> Options { get; }

        public GetRangeOfWorkStatusesQuery(IEnumerable<WorkStatusIncludeOptions> options)
        {
            Options = options ?? throw new ArgumentNullException(nameof(options));
        }
    }
}
