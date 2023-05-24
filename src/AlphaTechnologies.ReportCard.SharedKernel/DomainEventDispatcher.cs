﻿using AlphaTechnologies.ReportCard.SharedKernel.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.SharedKernel
{
    public class DomainEventDispatcher : IDomainEventDispatcher
    {
        private IMediator _mediator;

        public DomainEventDispatcher(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task DispatchAndClearEvents(IEnumerable<IDomainObject> entities)
        {
            foreach (var entity in entities)
            {
                foreach (var domainEvent in entity.DomainEvents)
                {
                    await _mediator.Publish(domainEvent).ConfigureAwait(false);
                }
                entity.ClearDomainEvents();
            }
        }
    }
}
