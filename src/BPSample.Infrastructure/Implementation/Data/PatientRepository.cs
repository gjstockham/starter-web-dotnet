namespace BPSample.Infrastructure.Implementation.Data
{
    using BPSample.Infrastructure.Persistence;
    using AutoMapper;
    using BPSample.Application.Common.Interfaces.Data;
    using BPSample.Domain.Patients;

    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        public PatientRepository(ApplicationDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext, mapper)
        {
        }
    }
}
