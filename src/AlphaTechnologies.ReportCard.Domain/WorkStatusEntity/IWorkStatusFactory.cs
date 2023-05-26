using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Domain.WorkStatusEntity
{
    public interface IWorkStatusFactory
    {
        WorkStatus Create(string code);
    }
}
