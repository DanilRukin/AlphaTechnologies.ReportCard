using AlphaTechnologies.ReportCard.Presentation.WPF.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Presentation.WPF.Models
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

        private string _result = "";
        public string Result { get => _result; protected set => Set(ref _result, value); } // Итого
    }
}
