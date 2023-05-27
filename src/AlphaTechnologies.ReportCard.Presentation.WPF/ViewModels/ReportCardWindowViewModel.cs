using AlphaTechnologies.ReportCard.Presentation.WPF.Models;
using AlphaTechnologies.ReportCard.Presentation.WPF.ViewModels.Base;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Presentation.WPF.ViewModels
{
    public class ReportCardWindowViewModel : ViewModel
    {
        #region Properties
        public event EventHandler? DialogComplete;

        protected virtual void OnDialogComplete(EventArgs e) => DialogComplete?.Invoke(this, e);

        private string _title = "Табель";
        public string Title { get => _title; set => Set(ref _title, value); }

        private string _status = "Status";
        public string Status { get => _status; set => Set(ref _status, value); }

        public ObservableCollection<EmployeeWithComingsModel> EmployeesTable { get; set; }

        public ObservableCollection<DepartmentModel> Departments { get; set; }
        #endregion


        public ReportCardWindowViewModel()
        {

        }

    }
}
