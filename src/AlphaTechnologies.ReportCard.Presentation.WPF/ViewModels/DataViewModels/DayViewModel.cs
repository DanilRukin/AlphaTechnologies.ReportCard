using AlphaTechnologies.ReportCard.Presentation.WPF.ViewModels.Base;
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
        private WorkStatusEnum _workStatus = WorkStatusEnum.FullDay;
        public WorkStatusEnum WorkStatus { get => _workStatus; set => Set(ref _workStatus, value); }
        
        private Brush _color = Brushes.Transparent;
        public Brush Color { get => _color; set => Set(ref _color, value); }
    }
}
