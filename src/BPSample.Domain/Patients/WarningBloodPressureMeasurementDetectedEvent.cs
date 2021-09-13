namespace BPSample.Domain.Patients
{
    using BPSample.Domain.Common;

    public class WarningBloodPressureMeasurementDetectedEvent : IDomainEvent
    {
        public WarningBloodPressureMeasurementDetectedEvent(Patient patient, BloodPressureMeasurement previousMeasurement, BloodPressureMeasurement latestMeasurement)
        {
            Patient = patient;
            PreviousMeasurement = previousMeasurement;
            LatestMeasurement = latestMeasurement;
        }

        public Patient Patient { get; }
        public BloodPressureMeasurement PreviousMeasurement { get; }
        public BloodPressureMeasurement LatestMeasurement { get; }
    }
}
