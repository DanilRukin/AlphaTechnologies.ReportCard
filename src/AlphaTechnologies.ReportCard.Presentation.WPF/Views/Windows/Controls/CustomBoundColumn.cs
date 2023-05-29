using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows;

namespace AlphaTechnologies.ReportCard.Presentation.WPF.Views.Windows.Controls
{
    public class CustomBoundColumn : DataGridTemplateColumn//DataGridBoundColumn
    {
        public DataTemplate CellTemplate { get; set; }
        public DataTemplate CellEditingTemplate { get; set; }
        public MappedValueCollection MappedValueCollection { get; set; }

        protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
        {
            var content = new ContentControl();
            MappedValue context = MappedValueCollection.ReturnIfExistAddIfNot(cell.Column.Header, dataItem);
            var binding = new Binding() { Source = context };
            content.ContentTemplate = cell.IsEditing ? CellEditingTemplate : CellTemplate;
            content.SetBinding(ContentControl.ContentProperty, binding);
            return content;
        }

        protected override FrameworkElement GenerateEditingElement(DataGridCell cell, object dataItem)
        {
            return GenerateElement(cell, dataItem);
        }
    }
}
