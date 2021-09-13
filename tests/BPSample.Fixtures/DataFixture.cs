namespace BPSample.Fixtures
{
    public class DataFixture
    {
        public PatientInviteFixture PatientInvites { get; } = new PatientInviteFixture();

        public OrganisationFixture Organisations { get; } = new OrganisationFixture();

        public PatientFixture Patients { get; } = new PatientFixture();

        public ClinicianFixture Clinicians { get; } = new ClinicianFixture();
    }
}
