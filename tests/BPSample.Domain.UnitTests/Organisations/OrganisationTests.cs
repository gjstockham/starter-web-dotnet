namespace BPSample.Domain.UnitTests.Organisations
{
    using System;
    using System.Linq;
    using BPSample.Domain.Organisations;
    using BPSample.Fixtures;
    using FluentAssertions;
    using Xunit;

    public class OrganisationTests : IClassFixture<DataFixture>
    {
        private readonly DataFixture dataFixture;

        public OrganisationTests(DataFixture dataFixture)
        {
            this.dataFixture = dataFixture;
        }

        [Fact]
        public void NewOrganisationThrowsIfNameNullOrEmpty()
        {
            FluentActions.Invoking(() => new Organisation(Guid.NewGuid(), null))
                .Should().ThrowExactly<ArgumentNullException>("null").Which.ParamName.Should().Be("name");

            FluentActions.Invoking(() => new Organisation(Guid.NewGuid(), string.Empty))
                .Should().ThrowExactly<ArgumentException>("empty").Which.ParamName.Should().Be("name");

            FluentActions.Invoking(() => new Organisation(Guid.NewGuid(), "   "))
                .Should().ThrowExactly<ArgumentException>("whitespace").Which.ParamName.Should().Be("name");
        }

        [Fact]
        public void NewOrganisationThrowsIfIdNotSet()
        {
            FluentActions.Invoking(() => new Organisation(Guid.Empty, "Name"))
                .Should().ThrowExactly<ArgumentException>("empty").Which.ParamName.Should().Be("id");
        }

        [Fact]
        public void NewOrganisationRaisesDomainEvent()
        {
            var organisation = dataFixture.Organisations.Generate();

            organisation.DomainEvents.Count.Should().Be(1);
            organisation.DomainEvents.First().Should().BeOfType<OrganisationCreatedEvent>()
                .Which.Organisation.Should().Be(organisation);
        }
    }
}
