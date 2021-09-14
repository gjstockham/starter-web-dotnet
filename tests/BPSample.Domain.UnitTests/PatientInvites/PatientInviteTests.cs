namespace BPSample.Domain.UnitTests.Organisations
{
    using System;
    using System.Linq;
    using BPSample.Domain.PatientInvites;
    using BPSample.Domain.Shared;
    using BPSample.Fixtures;
    using FluentAssertions;
    using Xunit;

    public class PatientInviteTests : IClassFixture<DataFixture>
    {
        private readonly DataFixture dataFixture;

        public PatientInviteTests(DataFixture dataFixture)
        {
            this.dataFixture = dataFixture;
        }

        [Fact]
        public void NewPatientInviteThrowsIfChiNull()
        {
            FluentActions.Invoking(() => new PatientInvite(null, "given", "family", "email", "sms", Guid.NewGuid()))
                .Should().ThrowExactly<ArgumentNullException>("null").Which.ParamName.Should().Be("chi");
        }

        [Fact]
        public void NewPatientInviteThrowsIfGivenNameNull()
        {
            FluentActions.Invoking(() => new PatientInvite(new ChiNumber("9999999999"), null, "family", "email", "sms", Guid.NewGuid()))
                .Should().ThrowExactly<ArgumentNullException>("null").Which.ParamName.Should().Be("givenName");

            FluentActions.Invoking(() => new PatientInvite(new ChiNumber("9999999999"), "", "family", "email", "sms", Guid.NewGuid()))
                .Should().ThrowExactly<ArgumentException>("empty").Which.ParamName.Should().Be("givenName");

            FluentActions.Invoking(() => new PatientInvite(new ChiNumber("9999999999"), "   ", "family", "email", "sms", Guid.NewGuid()))
                .Should().ThrowExactly<ArgumentException>("whitespace").Which.ParamName.Should().Be("givenName");
        }

        [Fact]
        public void NewPatientInviteThrowsIfFamilyNameNull()
        {
            FluentActions.Invoking(() => new PatientInvite(new ChiNumber("9999999999"), "given", null, "email", "sms", Guid.NewGuid()))
                .Should().ThrowExactly<ArgumentNullException>("null").Which.ParamName.Should().Be("familyName");

            FluentActions.Invoking(() => new PatientInvite(new ChiNumber("9999999999"), "given", "", "email", "sms", Guid.NewGuid()))
                .Should().ThrowExactly<ArgumentException>("empty").Which.ParamName.Should().Be("familyName");

            FluentActions.Invoking(() => new PatientInvite(new ChiNumber("9999999999"), "given", "   ", "email", "sms", Guid.NewGuid()))
                .Should().ThrowExactly<ArgumentException>("whitespace").Which.ParamName.Should().Be("familyName");
        }

        [Fact]
        public void NewPatientInviteThrowsIfEmailNull()
        {
            FluentActions.Invoking(() => new PatientInvite(new ChiNumber("9999999999"), "given", "family", null, "sms", Guid.NewGuid()))
                .Should().ThrowExactly<ArgumentNullException>("null").Which.ParamName.Should().Be("email");

            FluentActions.Invoking(() => new PatientInvite(new ChiNumber("9999999999"), "given", "family", "", "sms", Guid.NewGuid()))
                .Should().ThrowExactly<ArgumentException>("empty").Which.ParamName.Should().Be("email");

            FluentActions.Invoking(() => new PatientInvite(new ChiNumber("9999999999"), "given", "family", "  ", "sms", Guid.NewGuid()))
                .Should().ThrowExactly<ArgumentException>("whitespace").Which.ParamName.Should().Be("email");
        }

        [Fact]
        public void NewPatientInviteRaisesDomainEvent()
        {
            var patientInvite = dataFixture.PatientInvites.Generate();

            patientInvite.DomainEvents.Count.Should().Be(1);
            patientInvite.DomainEvents.First().Should().BeOfType<PatientInviteCreatedEvent>()
                .Which.PatientInvite.Should().Be(patientInvite);
        }
    }
}
