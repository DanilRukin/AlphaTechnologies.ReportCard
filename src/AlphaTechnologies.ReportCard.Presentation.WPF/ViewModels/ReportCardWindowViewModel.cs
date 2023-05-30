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
            GetAllDepartmentsQuery departmentsQuery = new(false);
            var departmentsResponse = await _mediator.Send(departmentsQuery);
            if (departmentsResponse.IsSuccess) 
            {
                foreach (var department in departmentsResponse.Value)
                {
                    Departments.Add(await DepartmentViewModel.Load(department.Id, 2023, _mediator));
                }               
            }
            SelectedDepartment = Departments.First();
        }

        private void FillJanuaryEmployeeTableWithTestData()
        {
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
