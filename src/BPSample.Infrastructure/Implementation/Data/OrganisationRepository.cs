namespace BPSample.Infrastructure.Implementation.Data
{
    using BPSample.Infrastructure.Persistence;
    using AutoMapper;
    using BPSample.Application.Common.Interfaces.Data;
    using BPSample.Domain.Organisations;

    public class OrganisationRepository : Repository<Organisation>, IOrganisationRepository
    {
        public OrganisationRepository(ApplicationDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext, mapper)
        {
        }
    }
}
