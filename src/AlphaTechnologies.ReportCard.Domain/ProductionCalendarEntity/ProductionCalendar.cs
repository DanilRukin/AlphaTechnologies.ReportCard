﻿using AlphaTechnologies.ReportCard.Domain.ComingEntity;
using AlphaTechnologies.ReportCard.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Domain.ProductionCalendarEntity
{
    public class ProductionCalendar : EntityBase<int>
    {
        public int Year { get; protected set; }
        public int Month { get; protected set; }
        private string _holidays = string.Empty;
        private List<DateOnly> _holidaysDates = new List<DateOnly>();
        public IReadOnlyCollection<DateOnly> Holidays
        {
            get
            {
                if (_holidays != string.Empty)
                {
                     _holidaysDates = HolidayDatesFromString(_holidays);
                }
                return _holidaysDates;
            }
        }

        private List<DateOnly> HolidayDatesFromString(string holidays)  // holidays = '1+,2*,12,13,20,21'
        {
            List<DateOnly> result = new List<DateOnly>();
            string[] digits = holidays.Split(',', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < digits.Length; i++)
            {
                digits[i] = RemoveSymbols(digits[i]);
                DateOnly date = new DateOnly(Year, Month, Convert.ToInt32(digits[i]));
                result.Add(date);
            }
            return result;
        }

        private string RemoveSymbols(string src)
        {
            StringBuilder builder = new StringBuilder(src.Length);
            for (int i = 0; i < src.Length; i++)
            {
                if (char.IsDigit(src[i]))
                    builder.Append(src[i]);
            }
            return builder.ToString();
        }

        protected ProductionCalendar() { }

        public bool IsHoliday(DateOnly date)
        {
            _holidaysDates ??= HolidayDatesFromString(_holidays);
            return _holidaysDates.Contains(date);
        }
    }
}
