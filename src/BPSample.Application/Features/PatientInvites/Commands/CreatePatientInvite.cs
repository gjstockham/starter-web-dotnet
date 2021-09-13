namespace BPSample.Application.Features.PatientInvites.Commands
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using BPSample.Application.Common.Interfaces.Data;
    using BPSample.Domain.PatientInvites;
    using BPSample.Domain.Shared;
    using MediatR;

    public static class CreatePatientInvite
    {
        public class Command : IRequest<Guid>
        {
            public string GivenName { get; set; } = null!;

            public string FamilyName { get; set; } = null!;

            public string CHI { get; set; } = null!;

            public string EmailAddress { get; set; } = null!;

            public string SmsNumber { get; set; } = null!;
        }

        public class Handler : IRequestHandler<Command, Guid>
        {
            private readonly IPatientInviteRepository repository;

            public Handler(IPatientInviteRepository repository)
            {
                this.repository = repository;
            }

            public async Task<Guid> Handle(Command request, CancellationToken cancellationToken)
            {
                var patientInvite = new PatientInvite(new ChiNumber(request.CHI), request.GivenName, request.FamilyName, request.EmailAddress, request.SmsNumber);

                repository.Add(patientInvite);

                await repository.UnitOfWork.SaveChangesAsync(cancellationToken);

                return patientInvite.Id;
            }
        }

    }
}

