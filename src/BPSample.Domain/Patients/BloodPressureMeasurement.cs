namespace BPSample.Domain.Patients
{
    using System;
    using System.Collections.Generic;
    using BPSample.Domain.Common;

    public class BloodPressureMeasurement : ValueObject
    {
        public BloodPressureMeasurement(int systolicValuemmHg, int diastolicValuemmHg, DateTimeOffset date)
        {
            Systolic = systolicValuemmHg;
            Diastolic = diastolicValuemmHg;
            Date = date;
            CalculateCategory();
        }

        public int Systolic { get; }

        public int Diastolic { get; }

        public DateTimeOffset Date { get; }

        public BloodPressureCategory Category { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Systolic;
            yield return Diastolic;
            yield return Date;
        }

        private void CalculateCategory()
        {
            // Could this be pattern based? 
            if (Systolic > 180 || Diastolic > 120)
            {
                Category = BloodPressureCategory.HypertensiveCrisis;
            }
            else if (Systolic >= 140 || Diastolic >= 90)
            {
                Category = BloodPressureCategory.HypertensionStage2;
            }
            else if ((Systolic >= 130 && Systolic <= 139) || (Diastolic >= 80 && Diastolic <= 89))
            {
                Category = BloodPressureCategory.HypertensionStage1;
            }
            else if ((Systolic >= 120 && Systolic <= 129) && Diastolic < 80)
            {
                Category = BloodPressureCategory.Elevated;
            }
            else if (Systolic < 120 && Diastolic < 80)
            {
                Category = BloodPressureCategory.Normal;
            }
            else
            {
                throw new ArgumentException("Cannot find a valid category for this blood pressure measurement");
            }
        }
    }
}
