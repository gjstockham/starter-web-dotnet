namespace BPSample.Domain.Common
{
    using System;
    using System.Collections.Generic;

    public class EntityBase
    {
        public Guid Id { get; protected set; }

        private readonly List<IDomainEvent> domainEvents = new List<IDomainEvent>();

        public IReadOnlyCollection<IDomainEvent> DomainEvents => domainEvents.AsReadOnly();

        public void ClearDomainEvents() => domainEvents.Clear();

        protected void AddDomainEvent(IDomainEvent @event)
        {
            domainEvents.Add(@event);
        }
    }
}
