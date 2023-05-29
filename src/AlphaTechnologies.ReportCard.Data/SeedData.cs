using AlphaTechnologies.ReportCard.Domain.ComingEntity;
using AlphaTechnologies.ReportCard.Domain.DepartmentAgregate;
using AlphaTechnologies.ReportCard.Domain.EmployeeAgregate;
using AlphaTechnologies.ReportCard.Domain.PositionEntity;
using AlphaTechnologies.ReportCard.Domain.ProductionCalendarEntity;
using AlphaTechnologies.ReportCard.Domain.WorkStatusEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Data
{
    public static class SeedData
    {
        private static bool _empty = false;
        private static bool _created = false;
        public static Department Department1 { get; private set; }
        public static Department Department2 { get; private set; }

        public static Employee Employee1_WorksOnDepartment1 { get; private set; }
        public static Employee Employee2_WorksOnDepartment1 { get; private set; }
        public static Employee Employee3_WorksOnDepartment2 { get; private set; }

        public static ProductionCalendar JanuaryProductionCalendar { get; private set; }

        public static List<Position> Positions { get; private set; } = new List<Position>();

        public static List<Position> Employee1_Positions { get; private set; } = new List<Position>();
        public static List<Position> Employee2_Positions { get; private set; } = new List<Position>();
        public static List<Position> Employee3_Positions { get; private set; } = new List<Position>();

        public static List<Coming> Employee1_JanuaryComings { get; private set; } = new List<Coming>();
        public static List<Coming> Employee2_JanuaryComings { get; private set; } = new List<Coming>();
        public static List<Coming> Employee3_JanuaryComings { get; private set; } = new List<Coming>();

        public static List<WorkStatus> WorkStatuses { get; private set; } = new List<WorkStatus>();

        public static void ApplyMigrationAndFillDatabase(AlphaTechnologiesRepordCardDbContext context)
        {
            context.Database.Migrate();
            ClearDatabase(context);
            FillDatabase(context);
            _created = true;
        }

        public static void InitializeDatabase(AlphaTechnologiesRepordCardDbContext context)
        {
            context.Database.EnsureCreated();
            ClearDatabase(context);
            FillDatabase(context);
            _created = true;
        }

        private static void FillDatabase(AlphaTechnologiesRepordCardDbContext context)
        {
            if (_empty)
            {
                DateTime startDate = DateTime.Today;
                DateTime endDate = startDate.AddDays(1);

                Department1 = new Department(nameof(Department1));
                Department2 = new Department(nameof(Department2));
                context.Departments.AddRange(Department1, Department2);
                context.SaveChanges();

                Employee1_WorksOnDepartment1 = new Employee(
                    new DateOnly(1977, 6, 6),
                    new ServiceNumber(GenerateServiceNumber(8)),
                    new PersonalData("Ivanov", "Ivan", "Ivanovich"),
                    new Address("Russia", "Barnaul", "Altay region", "Lenina", 15));

                Employee2_WorksOnDepartment1 = new Employee(
                    new DateOnly(1970, 12, 6),
                    new ServiceNumber(GenerateServiceNumber(8)),
                    new PersonalData("Petrov", "Ivan", "Petrovich"),
                    new Address("Russia", "Barnaul", "Altay region", "Lenina", 15));

                Employee3_WorksOnDepartment2 = new Employee(
                    new DateOnly(1983, 5, 16),
                    new ServiceNumber(GenerateServiceNumber(8)),
                    new PersonalData("Sidorov", "Petr", "Ivanovich"),
                    new Address("Russia", "Barnaul", "Altay region", "Lenina", 15));

                context.Employees.AddRange(Employee1_WorksOnDepartment1, Employee2_WorksOnDepartment1, Employee3_WorksOnDepartment2);
                context.SaveChanges();
                Department1.AddEmployee(Employee1_WorksOnDepartment1);
                Department1.AddEmployee(Employee2_WorksOnDepartment1);
                Department2.AddEmployee(Employee3_WorksOnDepartment2);
                context.SaveChanges();

                string holidays = "1,2,3,4,5,6,7,8,14,15,21,22,28,29";
                int year = 2023, month = 1;
                JanuaryProductionCalendar = ProductionCalendar.FromHolidays(year, month, holidays);
                context.ProductionCalendars.Add(JanuaryProductionCalendar);
                context.SaveChanges();

                Positions = new List<Position>
                { 
                    new Position("Повар"),
                    new Position("IT-директор"),
                    new Position("Техник"),
                    new Position("Программист"),
                    new Position("Бухгалтер"),
                };
                context.Positions.AddRange(Positions);
                context.SaveChanges();

                Employee1_Positions = new List<Position>
                {
                    Positions.First(p => p.Name == "IT-директор"),
                    Positions.First(p => p.Name == "Программист"),
                };
                Employee2_Positions = new List<Position>
                {
                    Positions.First(p => p.Name == "Бухгалтер")
                };
                Employee3_Positions = new List<Position>
                {
                    Positions.First(p => p.Name == "Повар"),
                    Positions.First(p => p.Name == "Техник"),
                };

                foreach (var position in Employee1_Positions)
                {
                    Employee1_WorksOnDepartment1.AddPosition(position);
                }
                foreach (var position in Employee2_Positions)
                {
                    Employee2_WorksOnDepartment1.AddPosition(position);
                }
                foreach (var position in Employee3_Positions)
                {
                    Employee3_WorksOnDepartment2.AddPosition(position);
                }
                context.SaveChanges();

               
                WorkStatuses = new List<WorkStatus>();
                foreach (var name in Enum.GetNames<WorkStatusEnum>())
                {
                    WorkStatuses.Add(new WorkStatus(name));
                }
                context.WorkStatuses.AddRange(WorkStatuses);
                context.SaveChanges();

                Random random = new Random();
                WorkStatus workStatus;
                Coming coming;
                var values = Enum.GetValues<WorkStatusEnum>();
                Array.Sort(values, (first, second) =>
                {
                    if ((int)first > (int)second)
                        return 1;
                    else if ((int)first < (int)second)
                        return -1;
                    else
                        return 0;
                });
                int maxCode = (int)values[0];
                for (int i = 1; i < 32; i++)
                {
                    workStatus = WorkStatuses.First(w => w.Code == ((WorkStatusEnum)random.Next(1, 11)).GetCode());
                    coming = Employee1_WorksOnDepartment1.CheckIn(new DateOnly(JanuaryProductionCalendar.Year, JanuaryProductionCalendar.Month, i), workStatus);
                    Employee1_JanuaryComings.Add(coming);

                    workStatus = WorkStatuses.First(w => w.Code == ((WorkStatusEnum)random.Next(1, 11)).GetCode());
                    coming = Employee2_WorksOnDepartment1.CheckIn(new DateOnly(JanuaryProductionCalendar.Year, JanuaryProductionCalendar.Month, i), workStatus);
                    Employee2_JanuaryComings.Add(coming);

                    workStatus = WorkStatuses.First(w => w.Code == ((WorkStatusEnum)random.Next(1, 11)).GetCode());
                    coming = Employee3_WorksOnDepartment2.CheckIn(new DateOnly(JanuaryProductionCalendar.Year, JanuaryProductionCalendar.Month, i), workStatus);
                    Employee3_JanuaryComings.Add(coming);
                }
                context.SaveChanges();

                _empty = false;
            }
        }

        private static void ClearDatabase(AlphaTechnologiesRepordCardDbContext context)
        {
            if (context.Departments.Any())
                context.Departments.RemoveRange(context.Departments);
            if (context.Employees.Any())
                context.Employees.RemoveRange(context.Employees);
            if (context.Positions.Any())
                context.Positions.RemoveRange(context.Positions);
            if (context.ProductionCalendars.Any())
                context.ProductionCalendars.RemoveRange(context.ProductionCalendars);
            if (context.WorkStatuses.Any())
                context.RemoveRange(context.WorkStatuses);
            if (context.Comings.Any())
                context.Comings.RemoveRange(context.Comings);
            context.SaveChanges();
            Department1 = null;
            Department2 = null;

            Employee1_WorksOnDepartment1 = null;
            Employee2_WorksOnDepartment1 = null;
            Employee3_WorksOnDepartment2 = null;

            JanuaryProductionCalendar = null;

            Positions.Clear();
            Employee1_Positions.Clear();
            Employee2_Positions.Clear();
            Employee3_Positions.Clear();
            Employee1_JanuaryComings.Clear();
            Employee2_JanuaryComings.Clear();
            Employee3_JanuaryComings.Clear();
            WorkStatuses.Clear();

            _empty = true;
        }

        public static void ResetDatabase(AlphaTechnologiesRepordCardDbContext context)
        {
            if (_created)
            {
                ClearDatabase(context);
                FillDatabase(context);
            }
        }

        private static string GenerateServiceNumber(int length)
        {
            Random random = new Random();
            StringBuilder builder = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                builder.Append(random.Next(1, 9));
            }
            return builder.ToString();
        }

        internal enum WorkStatusEnum
        {
            Unknown = 0,
            /// <summary>
            /// Полный день (Я)
            /// </summary>
            FullDay,
            /// <summary>
            /// Отсутсвие на рабочем месте (Н)
            /// </summary>
            NotOnWork,
            /// <summary>
            /// Выходные и праздничные дни (В)
            /// </summary>
            Holiday,
            /// <summary>
            /// Работа в праздничные и выходные дни (Рв)
            /// </summary>
            WorkOnHoliday,
            /// <summary>
            /// Дни временной нетрудоспособности (Б)
            /// </summary>
            Seek,
            /// <summary>
            /// Командировочные дни (К)
            /// </summary>
            BusinessTrip,
            /// <summary>
            /// Ежегодный основной оплаченный отпуск (ОТ)
            /// </summary>
            PaidVacation,
            /// <summary>
            /// Неоплачиваемый отпуск (До)
            /// </summary>
            UnpaidVacation,
            /// <summary>
            /// Хозяйственный день (Хд)
            /// </summary>
            BusinessDay,
            /// <summary>
            /// Отпуск на период обучения (У)
            /// </summary>
            LeaveForThePeriodOfStudy,
            /// <summary>
            /// Отпуск по уходу за ребенком (Ож)
            /// </summary>
            ParentalLeave,
        }

        internal static string GetCode(this WorkStatusEnum workStatusEnum) =>
            workStatusEnum switch
            {
                WorkStatusEnum.FullDay => "Я",
                WorkStatusEnum.NotOnWork => "Н",
                WorkStatusEnum.Holiday => "В",
                WorkStatusEnum.WorkOnHoliday => "Рв",
                WorkStatusEnum.Seek => "Б",
                WorkStatusEnum.BusinessTrip => "К",
                WorkStatusEnum.PaidVacation => "ОТ",
                WorkStatusEnum.UnpaidVacation => "До",
                WorkStatusEnum.BusinessDay => "Хд",
                WorkStatusEnum.LeaveForThePeriodOfStudy => "У",
                WorkStatusEnum.ParentalLeave => "Ож",
                WorkStatusEnum.Unknown => "",
                _ => throw new ArgumentException($"Cannot convert value '{workStatusEnum}'" +
                    $" to correct code"),
            };

        internal static WorkStatusEnum FromCode(this WorkStatusEnum workStatusEnum, string code) =>
            code switch
            {
                "" => WorkStatusEnum.Unknown,
                "Я" => WorkStatusEnum.FullDay,
                "Н" => WorkStatusEnum.NotOnWork,
                "В" => WorkStatusEnum.Holiday,
                "Рв" => WorkStatusEnum.WorkOnHoliday,
                "Б" => WorkStatusEnum.Seek,
                "К" => WorkStatusEnum.BusinessTrip,
                "ОТ" => WorkStatusEnum.PaidVacation,
                "До" => WorkStatusEnum.UnpaidVacation,
                "Хд" => WorkStatusEnum.BusinessDay,
                "У" => WorkStatusEnum.LeaveForThePeriodOfStudy,
                "Ож" => WorkStatusEnum.ParentalLeave,
                _ => throw new ArgumentException($"Code '{code}' can not be converted to WorkStatusEnum"),
            };
    }
}
