using AlphaTechnologies.ReportCard.Application.ComingsEntity.Queries;
using AlphaTechnologies.ReportCard.Application.DepartmentAgregate.Queries;
using AlphaTechnologies.ReportCard.Application.EmployeeAgregate;
using AlphaTechnologies.ReportCard.Application.EmployeeAgregate.Queries;
using AlphaTechnologies.ReportCard.Application.PositionEntity.Queries;
using AlphaTechnologies.ReportCard.Presentation.WPF.Models.Services;
using AlphaTechnologies.ReportCard.Presentation.WPF.ViewModels.Base;
using AlphaTechnologies.ReportCard.Presentation.WPF.ViewModels.DataViewModels;
using AlphaTechnologies.ReportCard.SharedKernel.Results;
using MediatR;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace AlphaTechnologies.ReportCard.Presentation.WPF.ViewModels
{
    public class ReportCardWindowViewModel : ViewModel
    {
        private IMediator _mediator;

        #region Properties
        public event EventHandler? DialogComplete;

        protected virtual void OnDialogComplete(EventArgs e) => DialogComplete?.Invoke(this, e);

        private string _title = "Табель";
        public string Title { get => _title; set => Set(ref _title, value); }

        private string _status = "Status";
        public string Status { get => _status; set => Set(ref _status, value); }

        public ObservableCollection<DepartmentViewModel> Departments { get; set; } =
            new ObservableCollection<DepartmentViewModel>();

        private DepartmentViewModel _selectedDepartment = new DepartmentViewModel("");
        public DepartmentViewModel SelectedDepartment { get => _selectedDepartment; set => Set(ref _selectedDepartment, value); }

        public ObservableCollection<EmployeeWorkStatusMounthViewModel> January { get; set; } =
            new ObservableCollection<EmployeeWorkStatusMounthViewModel>();
        #endregion

        public ReportCardWindowViewModel(IMediator mediator) : this()
        {
            _mediator = mediator;
        }

        public ReportCardWindowViewModel()
        {
            //for (int i = 0; i < 5; i++)
            //{
            //    Departments.Add(new DepartmentViewModel($"Name_{i}"));
            //}
            //FillJanuaryEmployeeTableWithTestData();
            //LoadDepartments();
        }


        #region Commands



        #endregion

        #region Methods

        public async Task LoadDepartments()
        {
            Departments.Clear();
            GetAllDepartmentsQuery query = new(true);
            GetRangeOfEmployeesQuery employeesQuery;
            GetRangeOfComingsQuery comingsQuery;
            GetRangeOfPositionsQuery positionsQuery;
            List<EmployeeIncludeOptions> employeeIncludeOptions = new List<EmployeeIncludeOptions>();
            DepartmentViewModel departmentViewModel;
            EmployeeWorkStatusMounthViewModel employeeWorkStatusMounthViewModel;
            var response = await _mediator.Send(query);
            if (response.IsSuccess)
            {
                foreach (var department in response.Value)
                {
                    departmentViewModel = new DepartmentViewModel(department.Name);
                    employeeIncludeOptions.Clear();
                    foreach (var id in department.EmployeesIds)
                    {
                        employeeIncludeOptions.Add(new EmployeeIncludeOptions(id, true, true));
                    }
                    employeesQuery = new(employeeIncludeOptions);
                    Result<IEnumerable<EmployeeDto>> employeesResponse = await _mediator.Send(employeesQuery);
                    if (employeesResponse.IsSuccess)
                    {
                        foreach (var employee in employeesResponse.Value)
                        {
                            positionsQuery = new(employee.PositionsIds.Select(id => new PositionIncludeOptions(id, false)));
                            var positionsResponse = await _mediator.Send(positionsQuery);

                            comingsQuery = new(employee.ComingDaysIds);
                            var comingsResponse = await _mediator.Send(comingsQuery);
                            if (comingsResponse.IsSuccess)
                            {
                                foreach (var coming in comingsResponse.Value)
                                {
                                    employeeWorkStatusMounthViewModel = new EmployeeWorkStatusMounthViewModel(
                                            $"{employee.FirstName} {employee.LastName} {employee.Patronymic}",
                                            employee.ServiceNumber,
                                            positionsResponse.Value.FirstOrDefault() == default ? "" : positionsResponse.Value.First().Name);
                                    // employeeWorkStatusMounthViewModel.Day_1 = new DayViewModel() {WorkStatus = coming. }; TODO: сделать загрузку WorkStatus
                                    switch (coming.Date.Month)
                                    {
                                        case 1: departmentViewModel.JanuaryEmployees.Add(employeeWorkStatusMounthViewModel); break;  // January
                                        case 2: departmentViewModel.FebruaryEmployees.Add(employeeWorkStatusMounthViewModel); break;  // February
                                        case 3: departmentViewModel.MarchEmployees.Add(employeeWorkStatusMounthViewModel); break;  // March
                                        case 4: departmentViewModel.AprilEmployees.Add(employeeWorkStatusMounthViewModel); break;  // April
                                        case 5: departmentViewModel.MayEmployees.Add(employeeWorkStatusMounthViewModel); break;  // May
                                        case 6: departmentViewModel.JuneEmployees.Add(employeeWorkStatusMounthViewModel); break;  // June
                                        case 7: departmentViewModel.JulyEmployees.Add(employeeWorkStatusMounthViewModel); break;  // July
                                        case 8: departmentViewModel.AugustEmployees.Add(employeeWorkStatusMounthViewModel); break;  // August
                                        case 9: departmentViewModel.SeptemberEmployees.Add(employeeWorkStatusMounthViewModel); break;  // September
                                        case 10: departmentViewModel.OctoberEmployees.Add(employeeWorkStatusMounthViewModel); break;  // October
                                        case 11: departmentViewModel.NovemberEmployees.Add(employeeWorkStatusMounthViewModel); break;  // November
                                        case 12: departmentViewModel.DecemberEmployees.Add(employeeWorkStatusMounthViewModel); break;  // December
                                    }
                                }
                            }
                            else
                            {
                                ResultErrorHandler.Handle(comingsResponse);
                            }
                        }
                    }
                    else
                    {
                        ResultErrorHandler.Handle(employeesResponse);
                    }
                    Departments.Add(departmentViewModel);
                }
            }
            else
            {
                ResultErrorHandler.Handle(response);
            }
            SelectedDepartment = Departments.First();
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

        #endregion
    }
}
