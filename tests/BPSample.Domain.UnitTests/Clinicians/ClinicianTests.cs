namespace BPSample.Domain.UnitTests.Organisations
{
    using System;
    using System.Linq;
    using BPSample.Domain.Clinicians;
    using BPSample.Fixtures;
    using FluentAssertions;
    using Xunit;

    public class ClinicianTests : IClassFixture<DataFixture>
    {
        private readonly DataFixture dataFixture;

        public ClinicianTests(DataFixture dataFixture)
        {
            this.dataFixture = dataFixture;
        }

        [Fact]
        public void NewClinicianThrowsIfGivenNameNull()
        {
            FluentActions.Invoking(() => new Clinician(null, "family", "email", Guid.NewGuid()))
                .Should().ThrowExactly<ArgumentNullException>("null").Which.ParamName.Should().Be("givenName");

            FluentActions.Invoking(() => new Clinician("", "family", "email", Guid.NewGuid()))
                .Should().ThrowExactly<ArgumentException>("empty").Which.ParamName.Should().Be("givenName");

            FluentActions.Invoking(() => new Clinician("   ", "family", "email", Guid.NewGuid()))
                .Should().ThrowExactly<ArgumentException>("whitespace").Which.ParamName.Should().Be("givenName");
        }

        [Fact]
        public void NewClinicianThrowsIfFamilyNameNull()
        {
            FluentActions.Invoking(() => new Clinician("given", null, "email", Guid.NewGuid()))
                .Should().ThrowExactly<ArgumentNullException>("null").Which.ParamName.Should().Be("familyName");

            FluentActions.Invoking(() => new Clinician("given", "", "email", Guid.NewGuid()))
                .Should().ThrowExactly<ArgumentException>("empty").Which.ParamName.Should().Be("familyName");

            FluentActions.Invoking(() => new Clinician("given", "   ", "email", Guid.NewGuid()))
                .Should().ThrowExactly<ArgumentException>("whitespace").Which.ParamName.Should().Be("familyName");
        }

        [Fact]
        public void NewClinicianThrowsIfEmailNull()
        {
            FluentActions.Invoking(() => new Clinician("given", "family", null, Guid.NewGuid()))
                .Should().ThrowExactly<ArgumentNullException>("null").Which.ParamName.Should().Be("email");

            FluentActions.Invoking(() => new Clinician("given", "family", "", Guid.NewGuid()))
                .Should().ThrowExactly<ArgumentException>("empty").Which.ParamName.Should().Be("email");

            FluentActions.Invoking(() => new Clinician("given", "family", "  ", Guid.NewGuid()))
                .Should().ThrowExactly<ArgumentException>("whitespace").Which.ParamName.Should().Be("email");
        }

        [Fact]
        public void NewClinicianRaisesDomainEvent()
        {
            var clinician = dataFixture.Clinicians.Generate();

            clinician.DomainEvents.Count.Should().Be(1);
            clinician.DomainEvents.First().Should().BeOfType<ClinicianCreatedEvent>()
                .Which.Clinician.Should().Be(clinician);
        }
    }
}
