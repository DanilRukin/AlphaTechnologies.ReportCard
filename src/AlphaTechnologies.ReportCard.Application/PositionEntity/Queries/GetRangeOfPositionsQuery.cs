using AlphaTechnologies.ReportCard.SharedKernel.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Application.PositionEntity.Queries
{
    public class GetRangeOfPositionsQuery : IRequest<Result<IEnumerable<PositionDto>>>
    {
        public IEnumerable<PositionIncludeOptions> PositionIncludeOptions { get; }

        public GetRangeOfPositionsQuery(IEnumerable<PositionIncludeOptions> positionIncludeOptions)
        {
            PositionIncludeOptions = positionIncludeOptions ?? throw new ArgumentNullException(nameof(positionIncludeOptions));
        }
    }
}
