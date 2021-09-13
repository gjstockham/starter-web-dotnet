namespace BPSample.Domain.Patients
{
    using System;
    using Ardalis.GuardClauses;
    using BPSample.Domain.Common;
    using BPSample.Domain.Shared;

    public class Patient : EntityBase
    {
        public Patient(ChiNumber chi, string givenName, string familyName, string emailAddress, string mobileNumber, Guid organisationId)
        {
            Guard.Against.NullOrWhiteSpace(givenName, nameof(givenName));
            Guard.Against.NullOrWhiteSpace(familyName, nameof(familyName));
            Guard.Against.NullOrWhiteSpace(emailAddress, nameof(emailAddress));
            CHI = chi;
            GivenName = givenName;
            FamilyName = familyName;
            EmailAddress = emailAddress;
            MobileNumber = mobileNumber;
            OrganisationId = organisationId;
            AddDomainEvent(new PatientCreatedEvent(this));
        }

        public ChiNumber CHI { get; private set; }

        public string GivenName { get; private set; }

        public string FamilyName { get; private set; }

        public string EmailAddress { get; private set; }

        public string? MobileNumber { get; private set; }

        public Guid OrganisationId { get; private set; }

        public BloodPressureMeasurement? MostRecentMeasurement { get; set; }

        public void AddNewBloodPressureMeasurement(BloodPressureMeasurement bloodPressureMeasurement)
        {
            Guard.Against.Null(bloodPressureMeasurement, nameof(bloodPressureMeasurement));

            if (MostRecentMeasurement != null)
            {
                Guard.Against.InvalidInput(bloodPressureMeasurement.Date, nameof(bloodPressureMeasurement), x => x < MostRecentMeasurement.Date);

                if (bloodPressureMeasurement.Category == BloodPressureCategory.HypertensionStage2 || bloodPressureMeasurement.Category == BloodPressureCategory.HypertensiveCrisis)
                {
                    AddDomainEvent(new DangerousBloodPressureMeasurementDetectedEvent(this, bloodPressureMeasurement));
                }

                if (bloodPressureMeasurement.Category == BloodPressureCategory.HypertensionStage2 && MostRecentMeasurement.Category == BloodPressureCategory.HypertensionStage2)
                {
                    AddDomainEvent(new WarningBloodPressureMeasurementDetectedEvent(this, MostRecentMeasurement, bloodPressureMeasurement));
                }
            }

            MostRecentMeasurement = bloodPressureMeasurement;
        }
    }
}
