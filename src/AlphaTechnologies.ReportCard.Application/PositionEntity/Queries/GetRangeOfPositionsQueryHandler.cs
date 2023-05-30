using AlphaTechnologies.ReportCard.Application.Services;
using AlphaTechnologies.ReportCard.Data;
using AlphaTechnologies.ReportCard.Domain.PositionEntity;
using AlphaTechnologies.ReportCard.SharedKernel.Results;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Application.PositionEntity.Queries
{
    public class GetRangeOfPositionsQueryHandler : IRequestHandler<GetRangeOfPositionsQuery, Result<IEnumerable<PositionDto>>>
    {
        private AlphaTechnologiesRepordCardDbContext _context;
        private IMapper _mapper;

        public GetRangeOfPositionsQueryHandler(AlphaTechnologiesRepordCardDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Result<IEnumerable<PositionDto>>> Handle(GetRangeOfPositionsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Position? position;
                List<Position> selectedPositions = new List<Position>();
                foreach (var option in request.PositionIncludeOptions)
                {
                    if (option.IncludeEmployees)
                    {
                        position = await _context.Positions
                            .IncludeEmployees()
                            .FirstOrDefaultAsync(p => p.Id == option.PositionId, cancellationToken);
                    }
                    else
                    {
                        position = await _context.Positions
                            .FirstOrDefaultAsync(p => p.Id == option.PositionId, cancellationToken);
                    }
                    if (position != null)
                        selectedPositions.Add(position);
                }
                return Result.Success(_mapper.Map<List<Position>, IEnumerable<PositionDto>>(selectedPositions));
            }
            catch (Exception e)
            {
                return ExceptionHandler.Handle<IEnumerable<PositionDto>>(e);
            }
        }
    }
}
