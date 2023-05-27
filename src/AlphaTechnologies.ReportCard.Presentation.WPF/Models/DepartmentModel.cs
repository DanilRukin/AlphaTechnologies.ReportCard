using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Presentation.WPF.Models
{
    public class DepartmentModel
    {
        public string Name { get; protected set; }

        public DepartmentModel(string name)
        {
            Name = name;
        }
    }
}
