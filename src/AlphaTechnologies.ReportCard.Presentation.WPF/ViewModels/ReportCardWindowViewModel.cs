using AlphaTechnologies.ReportCard.Application.DepartmentAgregate.Queries;
using AlphaTechnologies.ReportCard.Presentation.WPF.Models.Services;
using AlphaTechnologies.ReportCard.Presentation.WPF.ViewModels.Base;
using AlphaTechnologies.ReportCard.Presentation.WPF.ViewModels.DataViewModels;
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
        public DepartmentViewModel SelectedDepartment { get; set; } = new DepartmentViewModel("");

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



        #endregion

        public async Task LoadDepartments()
        {
            Departments.Clear();
            GetAllDepartmentsQuery query = new(true);
            var response = await _mediator.Send(query);
            if (response.IsSuccess)
            {
                foreach (var department in response.Value)
                {
                    Departments.Add(new DepartmentViewModel(department.Name));
                    // TODO: сделать заполнение посещений работников по месяцам
                }
            }
            else
            {
                ResultErrorHandler.Handle(response);
            }
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
