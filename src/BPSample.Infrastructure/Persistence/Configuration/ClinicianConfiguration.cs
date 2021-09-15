namespace BPSample.Infrastructure.Persistence.Configuration
{
    using BPSample.Domain.Clinicians;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ClinicianConfiguration : IEntityTypeConfiguration<Clinician>
    {
        public void Configure(EntityTypeBuilder<Clinician> builder)
        {
        }
    }
}
