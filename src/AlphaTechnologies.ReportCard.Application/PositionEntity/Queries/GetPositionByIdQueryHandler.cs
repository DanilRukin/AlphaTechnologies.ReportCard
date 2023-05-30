using AlphaTechnologies.ReportCard.Application.Services;
using AlphaTechnologies.ReportCard.Data;
using AlphaTechnologies.ReportCard.Domain.PositionEntity;
using AlphaTechnologies.ReportCard.SharedKernel.Results;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Application.PositionEntity.Queries
{
    public class GetPositionByIdQueryHandler : IRequestHandler<GetPositionByIdQuery, Result<PositionDto>>
    {
        private AlphaTechnologiesRepordCardDbContext _context;
        private IMapper _mapper;

        public GetPositionByIdQueryHandler(AlphaTechnologiesRepordCardDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Result<PositionDto>> Handle(GetPositionByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Position? position;
                if (request.Options.IncludeEmployees)
                {
                    position = await _context.Positions
                        .IncludeEmployees()
                        .FirstOrDefaultAsync(p => p.Id == request.Options.PositionId, cancellationToken);
                }
                else
                {
                    position = await _context.Positions
                        .FirstOrDefaultAsync(p => p.Id == request.Options.PositionId, cancellationToken);
                }
                if (position == null)
                    return Result<PositionDto>.NotFound($"No such position with id: '{request.Options.PositionId}'");
                else
                    return Result.Success(_mapper.Map<PositionDto>(position));
            }
            catch (Exception ex)
            {
                return ExceptionHandler.Handle<PositionDto>(ex);
            }
        }
    }
}
