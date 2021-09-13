namespace BPSample.Domain.Organisations
{
    using BPSample.Domain.Common;

    public class OrganisationCreatedEvent : IDomainEvent
    {
        public OrganisationCreatedEvent(Organisation organisation)
        {
            Organisation = organisation;
        }

        public Organisation Organisation { get; }
    }
}
