namespace BPSample.Domain.Patients
{
    using BPSample.Domain.Common;

    public class PatientBloodPressureMeasurementAddedEvent : IDomainEvent
    {
        public PatientBloodPressureMeasurementAddedEvent(Patient patient)
        {
            Patient = patient;
        }

        public Patient Patient { get; }
    }
}
