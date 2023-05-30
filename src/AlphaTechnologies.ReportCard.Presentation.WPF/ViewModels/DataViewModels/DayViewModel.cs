using AlphaTechnologies.ReportCard.Application.ComingsEntity.Queries;
using AlphaTechnologies.ReportCard.Application.ProductionCalendarEntity.Queries;
using AlphaTechnologies.ReportCard.Application.WorkStatusEntity.Queries;
using AlphaTechnologies.ReportCard.Presentation.WPF.ViewModels.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace AlphaTechnologies.ReportCard.Presentation.WPF.ViewModels.DataViewModels
{
    public class DayViewModel : ViewModel
    {
        private DateOnly _date = DateOnly.FromDateTime(DateTime.Now);
        public DateOnly Date { get => _date; set => Set(ref _date, value); }

        private WorkStatusEnum _workStatus = WorkStatusEnum.Unknown;
        public WorkStatusEnum WorkStatus { get => _workStatus; set => Set(ref _workStatus, value); }
        
        private Brush _color = Brushes.Transparent;
        public Brush Color { get => _color; set => Set(ref _color, value); }

        public static async Task<DayViewModel> Load(Guid comingId, IMediator mediator)
        {
            GetCommingByIdQuery comingQuery = new(comingId);
            var comingResponse = await mediator.Send(comingQuery);
            if (comingResponse.IsSuccess)
            {
                DayViewModel result = new DayViewModel();
                result.Date = comingResponse.Value.Date;
                GetWorkStatusByIdQuery workStatusQuery = new(new WorkStatusIncludeOptions(comingResponse.Value.WorkStatusId, false));
                var workStatusResult = await mediator.Send(workStatusQuery);
                if (workStatusResult.IsSuccess)
                {
                    result.WorkStatus = WorkStatusEnum.Unknown.FromCode(workStatusResult.Value.Code);                   
                    IsDateHolidayQuery isDateHolidayQuery = new(comingResponse.Value.Date);
                    var isDateHolidayResponse = await mediator.Send(isDateHolidayQuery);
                    if (isDateHolidayResponse.IsSuccess)
                    {
                        if (isDateHolidayResponse.Value == true)
                            result.Color = Brushes.Red;
                    }
                }
                return result;
            }
            else
            {
                return new DayViewModel();
            }
        }
    }
}
