using AlphaTechnologies.ReportCard.SharedKernel.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Application.ComingsEntity.Queries
{
    public class GetRangeOfComingsQuery : IRequest<Result<IEnumerable<ComingDto>>>
    {
        public IEnumerable<Guid> Ids { get; }

        public GetRangeOfComingsQuery(IEnumerable<Guid> ids)
        {
            Ids = ids ?? throw new ArgumentNullException(nameof(ids));
        }
    }
}
