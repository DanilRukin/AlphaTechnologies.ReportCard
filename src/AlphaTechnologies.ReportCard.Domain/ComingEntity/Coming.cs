using AlphaTechnologies.ReportCard.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Domain.ComingEntity
{
    public class Coming : EntityBase<int>
    {
        public DateOnly Date { get; protected set; }
        public int EmployeeId { get; protected set; }
        protected Coming() { }
        public Coming(int id, DateOnly date, int employeeId) 
        {

        }
    }
}
