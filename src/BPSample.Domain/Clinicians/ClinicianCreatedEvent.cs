namespace BPSample.Domain.Clinicians
{
    using BPSample.Domain.Common;

    public class ClinicianCreatedEvent : IDomainEvent
    {
        public ClinicianCreatedEvent(Clinician clinician)
        {
            Clinician = clinician;
        }

        public Clinician Clinician { get; }
    }
}
