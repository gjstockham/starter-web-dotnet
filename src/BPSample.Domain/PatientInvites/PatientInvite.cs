namespace BPSample.Domain.PatientInvites
{
    using System;
    using Ardalis.GuardClauses;
    using BPSample.Domain.Common;
    using BPSample.Domain.Shared;

    public class PatientInvite : EntityBase
    {
        protected PatientInvite()
        {
        }

        public PatientInvite(ChiNumber chi, string givenName, string familyName, string email, string smsNumber, Guid organisationId)
        {
            Guard.Against.Null(chi, nameof(chi));
            Guard.Against.NullOrWhiteSpace(givenName, nameof(givenName));
            Guard.Against.NullOrWhiteSpace(familyName, nameof(familyName));
            Guard.Against.NullOrWhiteSpace(email, nameof(email));
            Guard.Against.Default(organisationId, nameof(organisationId));

            Chi = chi;
            GivenName = givenName;
            FamilyName = familyName;
            Email = email;
            SmsNumber = smsNumber;
            OrganisationId = organisationId;
            AddDomainEvent(new PatientInviteCreatedEvent(this));
        }

        public ChiNumber Chi { get; } = null!;

        public string GivenName { get; } = null!;

        public string FamilyName { get; } = null!;

        public string Email { get; } = null!;

        public string SmsNumber { get; } = null!;

        public Guid OrganisationId { get; }
    }
}
