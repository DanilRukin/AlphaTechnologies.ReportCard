using AlphaTechnologies.ReportCard.Application.ComingsEntity.Queries;
using AlphaTechnologies.ReportCard.Application.DepartmentAgregate.Queries;
using AlphaTechnologies.ReportCard.Application.EmployeeAgregate.Queries;
using AlphaTechnologies.ReportCard.Presentation.WPF.ViewModels.Base;
using MediatR;
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

        public static async Task<DepartmentViewModel> Load(int departmentId, int year, IMediator mediator)
        {
            GetDepartmentByIdQuery departmentQuery = new GetDepartmentByIdQuery(new DepartmentIncludeOptions(departmentId, true));
            var departmentResponse = await mediator.Send(departmentQuery);
            if (departmentResponse.IsSuccess)
            {
                var department = departmentResponse.Value;
                DepartmentViewModel result = new DepartmentViewModel(department.Name);
                GetRangeOfEmployeesQuery employeesQuery = new(department.EmployeesIds.Select(id => new EmployeeIncludeOptions(id, false, true)));
                var employeesResponse = await mediator.Send(employeesQuery);
                if (employeesResponse.IsSuccess)
                {
                    var employees = employeesResponse.Value;
                    foreach (var employee in employees)
                    {
                        result.JanuaryEmployees.Add(await EmployeeWorkStatusMounthViewModel.Load(employee.Id, year, 1, mediator));
                        result.FebruaryEmployees.Add(await EmployeeWorkStatusMounthViewModel.Load(employee.Id, year, 2, mediator));
                        result.MarchEmployees.Add(await EmployeeWorkStatusMounthViewModel.Load(employee.Id, year, 3, mediator));
                        result.AprilEmployees.Add(await EmployeeWorkStatusMounthViewModel.Load(employee.Id, year, 4, mediator));
                        result.MayEmployees.Add(await EmployeeWorkStatusMounthViewModel.Load(employee.Id, year, 5, mediator));
                        result.JuneEmployees.Add(await EmployeeWorkStatusMounthViewModel.Load(employee.Id, year, 6, mediator));
                        result.JulyEmployees.Add(await EmployeeWorkStatusMounthViewModel.Load(employee.Id, year, 7, mediator));
                        result.AugustEmployees.Add(await EmployeeWorkStatusMounthViewModel.Load(employee.Id, year, 8, mediator));
                        result.SeptemberEmployees.Add(await EmployeeWorkStatusMounthViewModel.Load(employee.Id, year, 9, mediator));
                        result.OctoberEmployees.Add(await EmployeeWorkStatusMounthViewModel.Load(employee.Id, year, 10, mediator));
                        result.NovemberEmployees.Add(await EmployeeWorkStatusMounthViewModel.Load(employee.Id, year, 11, mediator));
                        result.DecemberEmployees.Add(await EmployeeWorkStatusMounthViewModel.Load(employee.Id, year, 12, mediator));
                    }
                }
                return result;
            }
            else
            {
                return new DepartmentViewModel("");
            }
        }
    }
}
