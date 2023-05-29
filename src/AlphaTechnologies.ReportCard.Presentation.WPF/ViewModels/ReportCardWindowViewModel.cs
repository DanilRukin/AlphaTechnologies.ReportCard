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

        public ObservableCollection<EmployeeWithComingsModel> JanuaryEmployeesTable { get; set; } =
            new ObservableCollection<EmployeeWithComingsModel>();
        public EmployeeWithComingsModel SelectedJanuaryEmployee { get; set; }

        public ObservableCollection<EmployeeWithComingsModel> FebruaryEmployeesTable { get; set; } =
            new ObservableCollection<EmployeeWithComingsModel>();
        public EmployeeWithComingsModel SelectedFebruaryEmployee { get; set; }

        public ObservableCollection<EmployeeWithComingsModel> MarchEmployeesTable { get; set; } =
            new ObservableCollection<EmployeeWithComingsModel>();
        public EmployeeWithComingsModel SelectedMarchEmployee { get; set; }

        public ObservableCollection<EmployeeWithComingsModel> AprilEmployeesTable { get; set; } =
            new ObservableCollection<EmployeeWithComingsModel>();
        public EmployeeWithComingsModel SelectedAprilEmployee { get; set; }

        public ObservableCollection<EmployeeWithComingsModel> MayEmployeesTable { get; set; } =
            new ObservableCollection<EmployeeWithComingsModel>();
        public EmployeeWithComingsModel SelectedMayEmployee { get; set; }

        public ObservableCollection<EmployeeWithComingsModel> JuneEmployeesTable { get; set; } =
            new ObservableCollection<EmployeeWithComingsModel>();
        public EmployeeWithComingsModel SelectedJuneEmployee { get; set; }

        public ObservableCollection<EmployeeWithComingsModel> JulyEmployeesTable { get; set; } =
            new ObservableCollection<EmployeeWithComingsModel>();
        public EmployeeWithComingsModel SelectedJulyEmployee { get; set; }

        public ObservableCollection<EmployeeWithComingsModel> AugustEmployeesTable { get; set; } =
            new ObservableCollection<EmployeeWithComingsModel>();
        public EmployeeWithComingsModel SelectedAugustEmployee { get; set; }

        public ObservableCollection<EmployeeWithComingsModel> SeptemberEmployeesTable { get; set; } =
            new ObservableCollection<EmployeeWithComingsModel>();
        public EmployeeWithComingsModel SelectedSeptemberEmployee { get; set; }

        public ObservableCollection<EmployeeWithComingsModel> OctoberEmployeesTable { get; set; } =
            new ObservableCollection<EmployeeWithComingsModel>();
        public EmployeeWithComingsModel SelectedOctoberEmployee { get; set; }

        public ObservableCollection<EmployeeWithComingsModel> NovemberEmployeesTable { get; set; } =
            new ObservableCollection<EmployeeWithComingsModel>();
        public EmployeeWithComingsModel SelectedNovemberEmployee { get; set; }

        public ObservableCollection<EmployeeWithComingsModel> DecemberEmployeesTable { get; set; } =
            new ObservableCollection<EmployeeWithComingsModel>();
        public EmployeeWithComingsModel SelectedDecemberEmployee { get; set; }


        public ObservableCollection<DepartmentModel> Departments { get; set; } =
            new ObservableCollection<DepartmentModel>();
        public DepartmentModel SelectedDepartment { get; set; }
        #endregion


        public ReportCardWindowViewModel()
        {
            for (int i = 0; i < 5; i++)
            {
                Departments.Add(new DepartmentModel($"Name_{i}"));
            }
            FillJanuaryEmployeeTableWithTestData();
        }


        private void FillJanuaryEmployeeTableWithTestData()
        {
            EmployeeWithComingsModel item;
            Random random = new Random();
            for (int i = 1; i < 6; i++)
            {
                item = new EmployeeWithComingsModel($"Ivanov_{i} Ivan Ivanovich",
                    Guid.NewGuid().ToString(), $"position_{i}");
                for (int j = 1; j < 32; j++)
                {
                    item.ComingDays.Add(new ComingDay(j, (WorkStatusEnum)random.Next(1, 11)));
                    ComingDays.Add(new ComingDay(j, (WorkStatusEnum)random.Next(1, 11)));
                }
                JanuaryEmployeesTable.Add(item);
            }
        }

        public ObservableCollection<ComingDay> ComingDays { get; set; } = new ObservableCollection<ComingDay>();
    }
}
