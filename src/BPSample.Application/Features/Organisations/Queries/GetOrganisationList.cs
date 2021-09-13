namespace BPSample.Application.Features.Organisations.Queries
{
    using BPSample.Application.Common.Interfaces.Data;
    using BPSample.Application.Common.Mapping;
    using BPSample.Domain.Organisations;
    using MediatR;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public static class GetOrganisationList
    {
        public class Query : IRequest<IEnumerable<OrganisationDto>>
        {
        }

        public class OrganisationDto : IMapFrom<Organisation>
        {
            public Guid Id { get; protected set; }
            public string? Name { get; protected set; }
        }

        public class Handler : IRequestHandler<Query, IEnumerable<OrganisationDto>>
        {
            private readonly IOrganisationRepository repository;

            public Handler(IOrganisationRepository repository)
            {
                this.repository = repository;
            }

            public Task<IEnumerable<OrganisationDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                return repository.GetProjectedAsync<OrganisationDto>();
            }
        }
    }
}
