namespace BPSample.Domain.Patients
{
    using BPSample.Domain.Common;

    public class DangerousBloodPressureMeasurementDetectedEvent : IDomainEvent
    {
        public DangerousBloodPressureMeasurementDetectedEvent(Patient patient, BloodPressureMeasurement measurement)
        {
            Patient = patient;
            Measurement = measurement;
        }

        public Patient Patient { get; }
        public BloodPressureMeasurement Measurement { get; }
    }
}
