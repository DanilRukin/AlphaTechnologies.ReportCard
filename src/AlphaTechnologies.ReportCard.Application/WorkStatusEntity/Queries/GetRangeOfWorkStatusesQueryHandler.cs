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
    public class GetRangeOfWorkStatusesQueryHandler : IRequestHandler<GetRangeOfWorkStatusesQuery, Result<IEnumerable<WorkStatusDto>>>
    {
        private AlphaTechnologiesRepordCardDbContext _context;
        private IMapper _mapper;

        public GetRangeOfWorkStatusesQueryHandler(AlphaTechnologiesRepordCardDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Result<IEnumerable<WorkStatusDto>>> Handle(GetRangeOfWorkStatusesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                WorkStatus? workStatus;
                List<WorkStatus> selectedStatuses = new List<WorkStatus>();
                foreach (var option in request.Options)
                {
                    if (option.IncludeComings)
                    {
                        workStatus = await _context.WorkStatuses
                            .IncludeComings()
                            .FirstOrDefaultAsync(w => w.Id == option.WorkStatusId, cancellationToken);
                    }
                    else
                    {
                        workStatus = await _context.WorkStatuses
                            .FirstOrDefaultAsync(w => w.Id == option.WorkStatusId, cancellationToken);
                    }
                    if (workStatus != null)
                        selectedStatuses.Add(workStatus);
                }
                return Result.Success(_mapper.Map<List<WorkStatus>, IEnumerable<WorkStatusDto>>(selectedStatuses));
            }
            catch (Exception e)
            {
                return ExceptionHandler.Handle<IEnumerable<WorkStatusDto>>(e);
            }
        }
    }
}
