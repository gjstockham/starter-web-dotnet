namespace BPSample.Application.UnitTests.PatientInvites.Commands
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using BPSample.Application.Common.Interfaces;
    using BPSample.Application.Common.Interfaces.Data;
    using BPSample.Application.Features.PatientInvites.Commands;
    using BPSample.Domain.PatientInvites;
    using FluentAssertions;
    using Moq;
    using Xunit;

    public class CreatePatientInviteTests
    {
        [Fact]
        public async Task ShouldSavePatientInviteToRepository()
        {
            var repository = new Mock<IPatientInviteRepository>();
            var uow = new Mock<IUnitOfWork>();
            repository.Setup(x => x.UnitOfWork).Returns(uow.Object);

            var command = new CreatePatientInvite.Command()
            {
                GivenName = "FirstName",
                FamilyName = "FamilyName",
                EmailAddress = "test@test.com",
                CHI = "1111111111",
                SmsNumber = "0987654321",
                OrganisationId = Guid.NewGuid()
            };

            var handler = new CreatePatientInvite.Handler(repository.Object);

            var result = await handler.Handle(command, CancellationToken.None);

            result.Should().Be(Guid.Empty);
            repository.Verify(x => x.Add(
                It.Is<PatientInvite>(y =>
                    y.Chi.Value == command.CHI &&
                    y.GivenName == command.GivenName &&
                    y.FamilyName == command.FamilyName &&
                    y.Email == command.EmailAddress &&
                    y.SmsNumber == command.SmsNumber)));
            uow.Verify(x => x.SaveChangesAsync(CancellationToken.None));
        }
    }
}
