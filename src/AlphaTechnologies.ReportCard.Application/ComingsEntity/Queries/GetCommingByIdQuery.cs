using AlphaTechnologies.ReportCard.SharedKernel.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Application.ComingsEntity.Queries
{
    public class GetCommingByIdQuery : IRequest<Result<ComingDto>>
    {
        public Guid Id { get; }

        public GetCommingByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
