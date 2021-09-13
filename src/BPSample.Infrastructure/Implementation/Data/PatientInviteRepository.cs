namespace BPSample.Infrastructure.Implementation.Data
{
    using BPSample.Infrastructure.Persistence;
    using AutoMapper;
    using BPSample.Application.Common.Interfaces.Data;
    using BPSample.Domain.PatientInvites;

    public class PatientInviteRepository : Repository<PatientInvite>, IPatientInviteRepository
    {
        public PatientInviteRepository(ApplicationDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext, mapper)
        {
        }
    }
}
