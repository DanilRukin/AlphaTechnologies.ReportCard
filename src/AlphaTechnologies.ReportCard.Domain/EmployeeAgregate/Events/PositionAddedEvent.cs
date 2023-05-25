﻿using AlphaTechnologies.ReportCard.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Domain.EmployeeAgregate.Events
{
    public class PositionAddedEvent : DomainEvent
    {
        public int EmployeeId { get; }
        public int PositionId { get; }

        public PositionAddedEvent(int employeeId, int positionId)
        {
            EmployeeId = employeeId;
            PositionId = positionId;
        }
    }
}
