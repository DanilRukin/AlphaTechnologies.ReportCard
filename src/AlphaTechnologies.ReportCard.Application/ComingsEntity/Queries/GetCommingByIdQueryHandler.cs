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
    public class GetCommingByIdQueryHandler : IRequestHandler<GetCommingByIdQuery, Result<ComingDto>>
    {
        private AlphaTechnologiesRepordCardDbContext _context;
        private IMapper _mapper;

        public GetCommingByIdQueryHandler(AlphaTechnologiesRepordCardDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Result<ComingDto>> Handle(GetCommingByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Coming? coming = await _context.Comings.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
                if (coming == null)
                    return Result<ComingDto>.NotFound($"No such coming with id: '{request.Id}'");
                else
                    return Result.Success(_mapper.Map<ComingDto>(coming));
            }
            catch (Exception e)
            {
                return ExceptionHandler.Handle<ComingDto>(e);
            }
        }
    }
}
