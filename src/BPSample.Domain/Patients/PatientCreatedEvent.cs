namespace BPSample.Domain.Patients
{
    using BPSample.Domain.Common;

    public class PatientCreatedEvent : IDomainEvent
    {
        public PatientCreatedEvent(Patient patient)
        {
            Patient = patient;
        }

        public Patient Patient { get; }
    }
}
