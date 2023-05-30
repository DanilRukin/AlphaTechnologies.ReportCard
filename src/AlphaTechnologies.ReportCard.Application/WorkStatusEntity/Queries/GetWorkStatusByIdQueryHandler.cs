using AlphaTechnologies.ReportCard.Application.Services;
using AlphaTechnologies.ReportCard.Data;
using AlphaTechnologies.ReportCard.Domain.WorkStatusEntity;
using AlphaTechnologies.ReportCard.SharedKernel.Results;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Application.WorkStatusEntity.Queries
{
    public class GetWorkStatusByIdQueryHandler : IRequestHandler<GetWorkStatusByIdQuery, Result<WorkStatusDto>>
    {
        private AlphaTechnologiesRepordCardDbContext _context;
        private IMapper _mapper;

        public GetWorkStatusByIdQueryHandler(AlphaTechnologiesRepordCardDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Result<WorkStatusDto>> Handle(GetWorkStatusByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                WorkStatus? workStatus;
                if (request.Options.IncludeComings)
                {
                    workStatus = await _context.WorkStatuses
                        .IncludeComings()
                        .FirstOrDefaultAsync(w => w.Id == request.Options.WorkStatusId, cancellationToken);
                }
                else
                {
                    workStatus = await _context.WorkStatuses
                        .FirstOrDefaultAsync(w => w.Id == request.Options.WorkStatusId, cancellationToken);
                }
                if (workStatus == null)
                    return Result<WorkStatusDto>.NotFound($"No such work status with id: '{request.Options.WorkStatusId}'");
                else
                    return Result.Success(_mapper.Map<WorkStatusDto>(workStatus));
            }
            catch (Exception ex)
            {
                return ExceptionHandler.Handle<WorkStatusDto>(ex);
            }
        }
    }
}
