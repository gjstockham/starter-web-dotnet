namespace BPSample.Domain.PatientInvites
{
    using BPSample.Domain.Common;

    public class PatientInviteCreatedEvent : IDomainEvent
    {
        public PatientInviteCreatedEvent(PatientInvite patientInvite)
        {
            PatientInvite = patientInvite;
        }

        public PatientInvite PatientInvite { get; }
    }
}
