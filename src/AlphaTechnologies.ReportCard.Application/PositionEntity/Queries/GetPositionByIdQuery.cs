using AlphaTechnologies.ReportCard.SharedKernel.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Application.PositionEntity.Queries
{
    public class GetPositionByIdQuery : IRequest<Result<PositionDto>>
    {
        public PositionIncludeOptions Options { get; }

        public GetPositionByIdQuery(PositionIncludeOptions options)
        {
            Options = options ?? throw new ArgumentNullException(nameof(options));
        }
    }
}
