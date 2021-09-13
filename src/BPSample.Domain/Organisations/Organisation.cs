namespace BPSample.Domain.Organisations
{
    using System;
    using Ardalis.GuardClauses;
    using BPSample.Domain.Common;

    public class Organisation : EntityBase
    {
        protected Organisation()
        {
        }

        public Organisation(Guid id, string name)
        {
            Guard.Against.NullOrWhiteSpace(name, nameof(name));
            Guard.Against.Default(id, nameof(id));

            Id = id;
            Name = name;
            AddDomainEvent(new OrganisationCreatedEvent(this));
        }

        public string Name { get; private set; } = null!;
    }
}
