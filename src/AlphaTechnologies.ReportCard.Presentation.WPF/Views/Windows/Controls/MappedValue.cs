using AlphaTechnologies.ReportCard.Presentation.WPF.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Presentation.WPF.Views.Windows.Controls
{
    public class MappedValue : ViewModel
    {
        object value;
        public object ColumnBinding { get; set; }
        public object RowBinding { get; set; }
        public object Value
        {
            get
            {
                return value;
            }
            set
            {
                if (this.value != value)
                {
                    this.value = value;
                    base.OnPropertyChanged("Value");
                }
            }
        }
    }
}
