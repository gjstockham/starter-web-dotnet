namespace BPSample.Domain.UnitTests.Organisations
{
    using System.Linq;
    using BPSample.Domain.Patients;
    using BPSample.Fixtures;
    using FluentAssertions;
    using Xunit;

    public class PatientTests : IClassFixture<DataFixture>
    {
        private readonly DataFixture dataFixture;

        public PatientTests(DataFixture dataFixture)
        {
            this.dataFixture = dataFixture;
        }

        [Fact]
        public void NewPatientInviteThrowsIfGivenNameNullOrEmpty()
        {
        }

        [Fact]
        public void NewPatientInviteRaisesDomainEvent()
        {
            var patient = dataFixture.Patients.Generate();

            patient.DomainEvents.Count.Should().Be(1);
            patient.DomainEvents.First().Should().BeOfType<PatientCreatedEvent>()
                .Which.Patient.Should().Be(patient);
        }
    }
}
