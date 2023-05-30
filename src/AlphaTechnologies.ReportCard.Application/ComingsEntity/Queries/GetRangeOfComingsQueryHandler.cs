using AlphaTechnologies.ReportCard.Application.Services;
using AlphaTechnologies.ReportCard.Data;
using AlphaTechnologies.ReportCard.Domain.ComingEntity;
using AlphaTechnologies.ReportCard.SharedKernel.Results;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Application.ComingsEntity.Queries
{
    public class GetRangeOfComingsQueryHandler : IRequestHandler<GetRangeOfComingsQuery, Result<IEnumerable<ComingDto>>>
    {
        private AlphaTechnologiesRepordCardDbContext _context;
        private IMapper _mapper;

        public GetRangeOfComingsQueryHandler(AlphaTechnologiesRepordCardDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Result<IEnumerable<ComingDto>>> Handle(GetRangeOfComingsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Coming? coming;
                List<Coming> selectedComings = new List<Coming>();
                foreach (var id in request.Ids)
                {
                    coming = await _context.Comings.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
                    if (coming != null)
                        selectedComings.Add(coming);
                }
                return Result.Success(_mapper.Map<List<Coming>, IEnumerable<ComingDto>>(selectedComings));
            }
            catch (Exception e)
            {
                return ExceptionHandler.Handle<IEnumerable<ComingDto>> (e);
            }
        }
    }
}
