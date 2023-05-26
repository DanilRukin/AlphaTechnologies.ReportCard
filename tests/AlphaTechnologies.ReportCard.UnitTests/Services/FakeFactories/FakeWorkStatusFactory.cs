using AlphaTechnologies.ReportCard.Domain.WorkStatusEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.UnitTests.Services.FakeFactories
{
    public class FakeWorkStatusFactory : IWorkStatusFactory
    {
        private int _nextId = 1;
        public WorkStatus Create(string code)
        {
            WorkStatus status = new WorkStatus(code);
            PropertyInfo? property = status.GetType().GetProperty(nameof(WorkStatus.Id));
            property.SetValue(status, _nextId);
            _nextId++;
            return status;
        }
    }
}
