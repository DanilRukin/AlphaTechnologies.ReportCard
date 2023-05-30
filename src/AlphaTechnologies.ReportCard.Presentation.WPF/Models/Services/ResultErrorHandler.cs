using AlphaTechnologies.ReportCard.SharedKernel.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AlphaTechnologies.ReportCard.Presentation.WPF.Models.Services
{
    internal class ResultErrorHandler
    {
        //public static void Handle<T>(Result<T> errorResult)
        //{
        //    MessageBox.Show(ErrorsToString(errorResult.Errors), "Error",
        //        MessageBoxButton.OK, MessageBoxImage.Error);
        //}
        public static void Handle(IResult errorResult)
        {
            MessageBox.Show(ErrorsToString(errorResult.Errors), "Error",
                MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private static string ErrorsToString(IEnumerable<string> errors)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string error in errors)
            {
                sb.AppendLine(error + ";");
            }
            return sb.ToString();
        }
    }
}
