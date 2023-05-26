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
        private List<Coming> _comings = new List<Coming>();
        public IReadOnlyCollection<Coming> Comings => _comings.AsReadOnly();

        public IReadOnlyCollection<DateOnly> Holidays => _holidaysDates.AsReadOnly();


        protected ProductionCalendar() { }

        public bool IsHoliday(DateOnly date)
        {
            _holidaysDates ??= new List<DateOnly>();
            return _holidaysDates.Contains(date);
        }
    }
}
