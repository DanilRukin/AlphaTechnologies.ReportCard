using AlphaTechnologies.ReportCard.Presentation.WPF.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Presentation.WPF.ViewModels.DataViewModels
{
    public class EmployeeWorkStatusMounthViewModel : ViewModel
    {
        public EmployeeWorkStatusMounthViewModel(string fio, string serviceNumber, string position)
        {
            FIO = fio;
            ServiceNumber = serviceNumber;
            Position = position;
        }
        public string FIO { get; protected set; }

        public string ServiceNumber { get; protected set; }

        public string Position { get; protected set; }

        private DayViewModel _day_1 = new DayViewModel();
        public DayViewModel Day_1 { get => _day_1; set => Set(ref _day_1, value); }

        private DayViewModel _day_2 = new DayViewModel();
        public DayViewModel Day_2 { get => _day_2; set => Set(ref _day_2, value); }

        private DayViewModel _day_3 = new DayViewModel();
        public DayViewModel Day_3 { get => _day_3; set => Set(ref _day_3, value); }

        private DayViewModel _day_4 = new DayViewModel();
        public DayViewModel Day_4 { get => _day_4; set => Set(ref _day_4, value); }

        private DayViewModel _day_5 = new DayViewModel();
        public DayViewModel Day_5 { get => _day_5; set => Set(ref _day_5, value); }

        private DayViewModel _day_6 = new DayViewModel();
        public DayViewModel Day_6 { get => _day_6; set => Set(ref _day_6, value); }

        private DayViewModel _day_7 = new DayViewModel();
        public DayViewModel Day_7 { get => _day_7; set => Set(ref _day_7, value); }

        private DayViewModel _day_8 = new DayViewModel();
        public DayViewModel Day_8 { get => _day_8; set => Set(ref _day_8, value); }

        private DayViewModel _day_9 = new DayViewModel();
        public DayViewModel Day_9 { get => _day_9; set => Set(ref _day_9, value); }

        private DayViewModel _day_10 = new DayViewModel();
        public DayViewModel Day_10 { get => _day_10; set => Set(ref _day_10, value); }

        private DayViewModel _day_11 = new DayViewModel();
        public DayViewModel Day_11 { get => _day_11; set => Set(ref _day_11, value); }

        private DayViewModel _day_12 = new DayViewModel();
        public DayViewModel Day_12 { get => _day_12; set => Set(ref _day_12, value); }

        private DayViewModel _day_13 = new DayViewModel();
        public DayViewModel Day_13 { get => _day_13; set => Set(ref _day_13, value); }

        private DayViewModel _day_14 = new DayViewModel();
        public DayViewModel Day_14 { get => _day_14; set => Set(ref _day_14, value); }

        private DayViewModel _day_15 = new DayViewModel();
        public DayViewModel Day_15 { get => _day_15; set => Set(ref _day_15, value); }

        private DayViewModel _day_16 = new DayViewModel();
        public DayViewModel Day_16 { get => _day_16; set => Set(ref _day_16, value); }

        private DayViewModel _day_17 = new DayViewModel();
        public DayViewModel Day_17 { get => _day_17; set => Set(ref _day_17, value); }

        private DayViewModel _day_18 = new DayViewModel();
        public DayViewModel Day_18 { get => _day_18; set => Set(ref _day_18, value); }

        private DayViewModel _day_19 = new DayViewModel();
        public DayViewModel Day_19 { get => _day_19; set => Set(ref _day_19, value); }

        private DayViewModel _day_20 = new DayViewModel();
        public DayViewModel Day_20 { get => _day_20; set => Set(ref _day_20, value); }

        private DayViewModel _day_21 = new DayViewModel();
        public DayViewModel Day_21 { get => _day_21; set => Set(ref _day_21, value); }

        private DayViewModel _day_22 = new DayViewModel();
        public DayViewModel Day_22 { get => _day_22; set => Set(ref _day_22, value); }

        private DayViewModel _day_23 = new DayViewModel();
        public DayViewModel Day_23 { get => _day_23; set => Set(ref _day_23, value); }

        private DayViewModel _day_24 = new DayViewModel();
        public DayViewModel Day_24 { get => _day_24; set => Set(ref _day_24, value); }

        private DayViewModel _day_25 = new DayViewModel();
        public DayViewModel Day_25 { get => _day_25; set => Set(ref _day_25, value); }

        private DayViewModel _day_26 = new DayViewModel();
        public DayViewModel Day_26 { get => _day_26; set => Set(ref _day_26, value); }

        private DayViewModel _day_27 = new DayViewModel();
        public DayViewModel Day_27 { get => _day_27; set => Set(ref _day_27, value); }

        private DayViewModel _day_28 = new DayViewModel();
        public DayViewModel Day_28 { get => _day_28; set => Set(ref _day_28, value); }

        private DayViewModel _day_29 = new DayViewModel();
        public DayViewModel Day_29 { get => _day_29; set => Set(ref _day_29, value); }

        private DayViewModel _day_30 = new DayViewModel();
        public DayViewModel Day_30 { get => _day_30; set => Set(ref _day_30, value); }

        private DayViewModel _day_31 = new DayViewModel();
        public DayViewModel Day_31 { get => _day_31; set => Set(ref _day_31, value); }

        public string Result { get; protected set; }
    }
}
