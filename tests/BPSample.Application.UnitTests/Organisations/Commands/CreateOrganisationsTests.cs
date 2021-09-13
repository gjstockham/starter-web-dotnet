namespace BPSample.Application.UnitTests.Organisations.Commands
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using BPSample.Application.Common.Interfaces;
    using BPSample.Application.Common.Interfaces.Data;
    using BPSample.Application.Features.Organisations.Commands;
    using BPSample.Domain.Organisations;
    using FluentAssertions;
    using Moq;
    using Xunit;

    public class CreateOrganisationsTests
    {
        [Fact]
        public async Task ShouldSaveOrganisationToRepository()
        {
            var repository = new Mock<IOrganisationRepository>();
            var uow = new Mock<IUnitOfWork>();
            repository.Setup(x => x.UnitOfWork).Returns(uow.Object);

            var command = new CreateOrganisation.Command()
            {
                Id = Guid.NewGuid(),
                Name = "Organisation"
            };

            var handler = new CreateOrganisation.Handler(repository.Object);

            var result = await handler.Handle(command, CancellationToken.None);

            result.Should().Be(command.Id);
            repository.Verify(x => x.Add(It.Is<Organisation>(y => y.Id == command.Id && y.Name == command.Name)));
            uow.Verify(x => x.SaveChangesAsync(CancellationToken.None));
        }
    }
}
