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

            CHI = chi;
            GivenName = givenName;
            FamilyName = familyName;
            Email = email;
            SmsNumber = smsNumber;
            OrganisationId = organisationId;
            AddDomainEvent(new PatientInviteCreatedEvent(this));
        }

        public ChiNumber CHI { get; private set; } = null!;

        public string GivenName { get; private set; } = null!;

        public string FamilyName { get; private set; } = null!;

        public string Email { get; private set; } = null!;

        public string SmsNumber { get; private set; } = null!;

        public Guid OrganisationId { get; private set; }
    }
}
