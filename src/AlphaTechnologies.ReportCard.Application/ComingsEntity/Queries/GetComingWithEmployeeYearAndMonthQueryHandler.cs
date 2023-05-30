using AlphaTechnologies.ReportCard.Application.Services;
using AlphaTechnologies.ReportCard.Data;
using AlphaTechnologies.ReportCard.Domain.ComingEntity;
using AlphaTechnologies.ReportCard.SharedKernel.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Application.ComingsEntity.Queries
{
    public class GetComingWithEmployeeYearAndMonthQueryHandler : IRequestHandler<GetComingWithEmployeeYearAndMonthQuery, Result<IEnumerable<ComingDto>>>
    {
        private AlphaTechnologiesRepordCardDbContext _context;
        private IMapper _mapper;

        public GetComingWithEmployeeYearAndMonthQueryHandler(AlphaTechnologiesRepordCardDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Result<IEnumerable<ComingDto>>> Handle(GetComingWithEmployeeYearAndMonthQuery request, CancellationToken cancellationToken)
        {
            try
            {
                IEnumerable<Coming> comings = _context.Comings
                    .Where(c => c.EmployeeId == request.EmployeeId && c.Date.Year == request.Year && c.Date.Month == request.Month);
                if (comings != null)
                {
                    return Result.Success(_mapper.Map<IEnumerable<Coming>, IEnumerable<ComingDto>>(comings));
                }
                else
                {
                    return Result.Success(new List<ComingDto>().AsEnumerable());
                }

            }
            catch (Exception e)
            {
                return ExceptionHandler.Handle<IEnumerable<ComingDto>>(e);
            }
        }
    }
}
