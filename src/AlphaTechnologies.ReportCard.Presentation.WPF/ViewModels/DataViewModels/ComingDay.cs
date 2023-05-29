using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace AlphaTechnologies.ReportCard.Presentation.WPF.ViewModels.DataViewModels
{
    public class ComingDay : DataGridTextColumn
    {
        public int Number { get; set; }
        public WorkStatusEnum WorkStatus { get; set; }

        public ComingDay(int number, WorkStatusEnum workStatus) : base()
        {
            Number = number;
            WorkStatus = workStatus;
            Header = Number;
            Binding = new Binding(nameof(WorkStatus));
        }

        //protected override FrameworkElement GenerateEditingElement(DataGridCell cell, object dataItem)
        //{
        //    return GenerateElement(cell, dataItem);
        //}

        //protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
        //{
        //    var col = new DataGridTextColumn() { Header = Number, Binding = new Binding(WorkStatus.GetCode()) };
        //    return (FrameworkElement)(col.GetType().GetMethod(
        //        nameof(GenerateEditingElement),
        //        BindingFlags.Instance | BindingFlags.NonPublic,
        //        Type.DefaultBinder,
        //        new[] { typeof(DataGridCell), typeof(object) },
        //        null).Invoke(col, new object[] { cell, dataItem }));
        //}
    }
}
