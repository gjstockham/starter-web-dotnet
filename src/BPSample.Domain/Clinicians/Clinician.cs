namespace BPSample.Domain.Clinicians
{
    using System;
    using Ardalis.GuardClauses;
    using BPSample.Domain.Common;

    public class Clinician : EntityBase
    {
        protected Clinician()
        {
        }

        public Clinician(string givenName, string familyName, string email, Guid organisationId)
        {
            Guard.Against.NullOrWhiteSpace(givenName, nameof(givenName));
            Guard.Against.NullOrWhiteSpace(familyName, nameof(familyName));
            Guard.Against.NullOrWhiteSpace(email, nameof(email));
            Guard.Against.Default(organisationId, nameof(organisationId));

            GivenName = givenName;
            FamilyName = familyName;
            EmailAddress = email;
            OrganisationId = organisationId;

            // Should this be in a factory Create rather than constructor?
            AddDomainEvent(new ClinicianCreatedEvent(this));
        }

        public string GivenName { get; private set; } = null!;

        public string FamilyName { get; private set; } = null!;

        public string EmailAddress { get; private set; } = null!;

        public Guid OrganisationId { get; private set; }
    }
}
