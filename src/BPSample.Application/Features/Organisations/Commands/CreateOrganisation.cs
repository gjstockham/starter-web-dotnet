namespace BPSample.Application.Features.Organisations.Commands
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using BPSample.Application.Common.Interfaces.Data;
    using BPSample.Domain.Organisations;
    using MediatR;

    public static class CreateOrganisation
    {
        public class Command : IRequest<Guid>
        {
            public Guid Id { get; set; }

            public string Name { get; set; } = null!;
        }

        public class Handler : IRequestHandler<Command, Guid>
        {
            private readonly IOrganisationRepository repository;

            public Handler(IOrganisationRepository unitOfWork)
            {
                this.repository = unitOfWork;
            }

            public async Task<Guid> Handle(Command request, CancellationToken cancellationToken)
            {
                var organisation = new Organisation(request.Id, request.Name);

                repository.Add(organisation);

                await repository.UnitOfWork.SaveChangesAsync(cancellationToken);

                return organisation.Id;
            }
        }
    }
}
