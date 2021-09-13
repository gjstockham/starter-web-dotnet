namespace BPSample.Infrastructure.Implementation.Data
{
    using BPSample.Infrastructure.Persistence;
    using AutoMapper;
    using BPSample.Application.Common.Interfaces.Data;
    using BPSample.Domain.Clinicians;

    public class ClinicianRepository : Repository<Clinician>, IClinicianRepository
    {
        public ClinicianRepository(ApplicationDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext, mapper)
        {
        }
    }
}
