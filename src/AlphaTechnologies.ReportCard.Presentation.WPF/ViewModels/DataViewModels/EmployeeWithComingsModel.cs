using AlphaTechnologies.ReportCard.Presentation.WPF.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Presentation.WPF.ViewModels.DataViewModels
{
    public class EmployeeWithComingsModel : ViewModel
    {
        private string _fio = "";
        public string FIO { get => _fio; protected set => Set(ref _fio, value); }

        private string _serviceNamber = "";
        public string ServiceNumber { get => _serviceNamber; protected set => Set(ref _serviceNamber, value); }

        private string _position = "";
        public string Position { get => _position; protected set => Set(ref _position, value); }

        public ObservableCollection<ComingDay> ComingDays { get; set; } = new ObservableCollection<ComingDay>();

        public string Result
        {
            get
            {
                int fullDayCount = 0, unknownCount = 0, notOnWorkCount = 0, holidayCount = 0,
                    workOnHolidayCount = 0, seekCount = 0, businessTripCount = 0, paidVacationCount = 0,
                    unpaidVacationCount = 0, businessDayCount = 0, leaveForThePeriodOfStudyCount = 0,
                    parentalLeaveCount = 0;
                foreach (var comingDay in ComingDays)
                {
                    switch (comingDay.WorkStatus)
                    {
                        case WorkStatusEnum.FullDay: fullDayCount++; break;
                        case WorkStatusEnum.Unknown: unknownCount++; break;
                        case WorkStatusEnum.NotOnWork: notOnWorkCount++; break;
                        case WorkStatusEnum.Holiday: holidayCount++; break;
                        case WorkStatusEnum.WorkOnHoliday: workOnHolidayCount++; break;
                        case WorkStatusEnum.Seek: seekCount++; break;
                        case WorkStatusEnum.BusinessTrip: businessTripCount++; break;
                        case WorkStatusEnum.PaidVacation: paidVacationCount++; break;
                        case WorkStatusEnum.UnpaidVacation: unpaidVacationCount++; break;
                        case WorkStatusEnum.BusinessDay: businessDayCount++; break;
                        case WorkStatusEnum.LeaveForThePeriodOfStudy: leaveForThePeriodOfStudyCount++; break;
                        case WorkStatusEnum.ParentalLeave: parentalLeaveCount++; break;
                    }
                }
                StringBuilder builder = new StringBuilder(100);
                if (fullDayCount > 0)
                    builder.Append($"{WorkStatusEnum.FullDay.GetCode()}({fullDayCount});");
                if (notOnWorkCount > 0)
                    builder.Append($"{WorkStatusEnum.NotOnWork.GetCode()}({notOnWorkCount});");
                if (holidayCount > 0)
                    builder.Append($"{WorkStatusEnum.Holiday.GetCode()}({holidayCount});");
                if (workOnHolidayCount > 0)
                    builder.Append($"{WorkStatusEnum.WorkOnHoliday.GetCode()}({workOnHolidayCount});");
                if (seekCount > 0)
                    builder.Append($"{WorkStatusEnum.Seek.GetCode()}({seekCount});");
                if (businessTripCount > 0)
                    builder.Append($"{WorkStatusEnum.BusinessTrip.GetCode()}({businessTripCount});");
                if (paidVacationCount > 0)
                    builder.Append($"{WorkStatusEnum.PaidVacation.GetCode()}({paidVacationCount});");
                if (unpaidVacationCount > 0)
                    builder.Append($"{WorkStatusEnum.UnpaidVacation.GetCode()}({unpaidVacationCount});");
                if (businessDayCount > 0)
                    builder.Append($"{WorkStatusEnum.BusinessDay.GetCode()}({businessDayCount});");
                if (leaveForThePeriodOfStudyCount > 0)
                    builder.Append($"{WorkStatusEnum.LeaveForThePeriodOfStudy.GetCode()}({leaveForThePeriodOfStudyCount});");
                if (parentalLeaveCount > 0)
                    builder.Append($"{WorkStatusEnum.ParentalLeave}({parentalLeaveCount});");
                return builder.ToString();
            }
        } // Итого

        public EmployeeWithComingsModel(string fio, string serviceNumber, string position)
        {
            FIO = fio;
            ServiceNumber = serviceNumber;
            Position = position;
        }
    }
}
