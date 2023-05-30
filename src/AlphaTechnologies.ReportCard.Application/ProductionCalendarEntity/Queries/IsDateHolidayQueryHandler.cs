using AlphaTechnologies.ReportCard.Application.Services;
using AlphaTechnologies.ReportCard.Data;
using AlphaTechnologies.ReportCard.Domain.ProductionCalendarEntity;
using AlphaTechnologies.ReportCard.SharedKernel.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Application.ProductionCalendarEntity.Queries
{
    public class IsDateHolidayQueryHandler : IRequestHandler<IsDateHolidayQuery, Result<bool>>
    {
        private AlphaTechnologiesRepordCardDbContext _context;

        public IsDateHolidayQueryHandler(AlphaTechnologiesRepordCardDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<bool>> Handle(IsDateHolidayQuery request, CancellationToken cancellationToken)
        {
            try
            {
                ProductionCalendar? calendar = await _context.ProductionCalendars
                    .FirstOrDefaultAsync(pc => pc.Year == request.Date.Year && pc.Month == request.Date.Month, cancellationToken);
                if (calendar == null)
                    return Result.Success(false);
                else
                    return Result.Success(calendar.IsHoliday(request.Date));
            }
            catch (Exception e)
            {
                return ExceptionHandler.Handle<bool>(e);
            }
        }
    }
}
