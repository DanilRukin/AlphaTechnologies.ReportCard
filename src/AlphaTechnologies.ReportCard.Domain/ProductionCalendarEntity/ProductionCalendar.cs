using AlphaTechnologies.ReportCard.Domain.ComingEntity;
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
        public IReadOnlyCollection<DateOnly> Holidays => _holidaysDates.AsReadOnly();

        private void FillHolidayDatesFromString(string holidays)  // holidays = '1+,2*,12,13,20,21'
        {
            string[] digits = holidays.Split(',', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < digits.Length; i++)
            {
                digits[i] = RemoveSymbols(digits[i]);
                DateOnly date = new DateOnly(Year, Month, Convert.ToInt32(digits[i]));
                _holidaysDates.Add(date);
            }
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
            _holidaysDates ??= new List<DateOnly>();
            return _holidaysDates.Contains(date);
        }
    }
}
