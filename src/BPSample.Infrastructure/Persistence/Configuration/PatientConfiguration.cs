namespace BPSample.Infrastructure.Persistence.Configuration
{
    using BPSample.Domain.Patients;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.OwnsOne(x => x.CHI);
            builder.OwnsOne(x => x.MostRecentMeasurement);
        }
    }
}
