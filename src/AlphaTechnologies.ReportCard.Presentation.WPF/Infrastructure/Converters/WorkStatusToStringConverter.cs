using AlphaTechnologies.ReportCard.Presentation.WPF.Infrastructure.Converters.Base;
using AlphaTechnologies.ReportCard.Presentation.WPF.ViewModels.DataViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Presentation.WPF.Infrastructure.Converters
{
    public class WorkStatusToStringConverter : Converter
    {
        /// <summary>
        /// Converts WorkStatusEnum to string
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is WorkStatusEnum workStatus)
            {
                return workStatus.GetCode();
            }
            else
            {
                return "Not supported";
            }
        }
        /// <summary>
        /// Converts string to WorkStatusEnum
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string  workStatus)
            {
                return WorkStatusEnum.Unknown.FromCode(workStatus);
            }
            else
            {
                throw new ArgumentException("Value is not a string");
            }
        }
    }
}
