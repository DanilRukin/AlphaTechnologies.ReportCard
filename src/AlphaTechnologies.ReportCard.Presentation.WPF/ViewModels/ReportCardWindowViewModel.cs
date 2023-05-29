using AlphaTechnologies.ReportCard.Presentation.WPF.ViewModels.Base;
using AlphaTechnologies.ReportCard.Presentation.WPF.ViewModels.DataViewModels;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

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

        public ObservableCollection<DepartmentViewModel> Departments { get; set; } =
            new ObservableCollection<DepartmentViewModel>();
        public DepartmentViewModel SelectedDepartment { get; set; } = new DepartmentViewModel("");

        public ObservableCollection<EmployeeWorkStatusMounthViewModel> January { get; set; } =
            new ObservableCollection<EmployeeWorkStatusMounthViewModel>();
        #endregion


        public ReportCardWindowViewModel()
        {
            for (int i = 0; i < 5; i++)
            {
                Departments.Add(new DepartmentViewModel($"Name_{i}"));
            }
            FillJanuaryEmployeeTableWithTestData();
        }


        private void FillJanuaryEmployeeTableWithTestData()
        {
            EmployeeWithComingsModel item;
            Random random = new Random();
            for (int i = 1; i < 6; i++)
            {
                January.Add(new EmployeeWorkStatusMounthViewModel($"Ivanov_{i} Ivan Ivanovich",
                    Guid.NewGuid().ToString(), $"position_{i}"));
            }
        }
    }
}
