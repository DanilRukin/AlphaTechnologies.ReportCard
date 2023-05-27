using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Presentation.WPF.Models
{
    public enum WorkStatusEnum
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

    public static class EnumExtensions
    {
        public static string GetCode(this WorkStatusEnum workStatusEnum) =>
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
    }
}
