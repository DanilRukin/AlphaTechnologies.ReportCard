using AlphaTechnologies.ReportCard.Presentation.WPF.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Presentation.WPF.ViewModels.DataViewModels
{
    public class DepartmentViewModel : ViewModel
    {
        public string Name { get; protected set; }

        public ObservableCollection<EmployeeWorkStatusMounthViewModel> JanuaryEmployees { get; protected set; } =
            new ObservableCollection<EmployeeWorkStatusMounthViewModel>();

        public ObservableCollection<EmployeeWorkStatusMounthViewModel> FebruaryEmployees { get; protected set; } =
            new ObservableCollection<EmployeeWorkStatusMounthViewModel>();

        public ObservableCollection<EmployeeWorkStatusMounthViewModel> MarchEmployees { get; protected set; } =
            new ObservableCollection<EmployeeWorkStatusMounthViewModel>();

        public ObservableCollection<EmployeeWorkStatusMounthViewModel> AprilEmployees { get; protected set; } =
            new ObservableCollection<EmployeeWorkStatusMounthViewModel>();

        public ObservableCollection<EmployeeWorkStatusMounthViewModel> MayEmployees { get; protected set; } =
            new ObservableCollection<EmployeeWorkStatusMounthViewModel>();

        public ObservableCollection<EmployeeWorkStatusMounthViewModel> JuneEmployees { get; protected set; } =
            new ObservableCollection<EmployeeWorkStatusMounthViewModel>();

        public ObservableCollection<EmployeeWorkStatusMounthViewModel> JulyEmployees { get; protected set; } =
            new ObservableCollection<EmployeeWorkStatusMounthViewModel>();

        public ObservableCollection<EmployeeWorkStatusMounthViewModel> AugustEmployees { get; protected set; } =
            new ObservableCollection<EmployeeWorkStatusMounthViewModel>();

        public ObservableCollection<EmployeeWorkStatusMounthViewModel> SeptemberEmployees { get; protected set; } =
            new ObservableCollection<EmployeeWorkStatusMounthViewModel>();

        public ObservableCollection<EmployeeWorkStatusMounthViewModel> OctoberEmployees { get; protected set; } =
            new ObservableCollection<EmployeeWorkStatusMounthViewModel>();

        public ObservableCollection<EmployeeWorkStatusMounthViewModel> NovemberEmployees { get; protected set; } =
            new ObservableCollection<EmployeeWorkStatusMounthViewModel>();

        public ObservableCollection<EmployeeWorkStatusMounthViewModel> DecemberEmployees { get; protected set; } =
            new ObservableCollection<EmployeeWorkStatusMounthViewModel>();

        public DepartmentViewModel(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
