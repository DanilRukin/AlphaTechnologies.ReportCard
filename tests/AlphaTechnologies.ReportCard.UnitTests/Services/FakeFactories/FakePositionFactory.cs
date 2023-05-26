using AlphaTechnologies.ReportCard.Domain.PositionEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.UnitTests.Services.FakeFactories
{
    public class FakePositionFactory : IPositionFactory
    {
        private int _nextId = 1;
        public Position Create(string name)
        {
            Position position = new Position(name);
            PropertyInfo? property = position.GetType().GetProperty(nameof(Position.Id));
            property.SetValue(position, _nextId);
            _nextId++;
            return position;
        }
    }
}
