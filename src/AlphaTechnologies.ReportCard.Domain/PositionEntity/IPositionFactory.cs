using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Domain.PositionEntity
{
    public interface IPositionFactory
    {
        Position Create(string name);
    }
}
