namespace BPSample.Infrastructure.Persistence.Configuration
{
    using BPSample.Domain.PatientInvites;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PatientInviteConfiguration : IEntityTypeConfiguration<PatientInvite>
    {
        public void Configure(EntityTypeBuilder<PatientInvite> builder)
        {
            builder.OwnsOne(x => x.CHI);
        }
    }
}
