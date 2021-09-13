namespace BPSample.Application.UnitTests.Organisations.Queries
{
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using BPSample.Application.Common.Interfaces.Data;
    using BPSample.Application.Features.Organisations.Queries;
    using BPSample.Domain.Organisations;
    using FluentAssertions;
    using Moq;
    using Xunit;

    public class GetOrganisationListTests
    {
        [Fact]
        public async Task ShouldGetOrganisationList()
        {
            var repository = new Mock<IOrganisationRepository>();
            var query = new GetOrganisationList.Query();
            var expected = new[] { new GetOrganisationList.OrganisationDto() };
            repository.Setup(x => x.GetProjectedAsync<GetOrganisationList.OrganisationDto>()).ReturnsAsync(expected);

            var handler = new GetOrganisationList.Handler(repository.Object);

            var result = await handler.Handle(query, CancellationToken.None);

            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void ShouldMapDto()
        {
            var configuration = new MapperConfiguration(cfg =>
                cfg.CreateMap<Organisation, GetOrganisationList.OrganisationDto>());

            configuration.AssertConfigurationIsValid();
        }
    }
}
