namespace BPSample.Infrastructure.Persistence
{
    using BPSample.Application.Common.Interfaces;
    using BPSample.Domain.Common;
    using BPSample.Domain.Organisations;
    using BPSample.Infrastructure.Persistence.Configuration;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class ApplicationDbContext : DbContext, IUnitOfWork
    {
        private readonly IDateTime dateTime;
        private readonly ICurrentUserService currentUserService;
        private readonly IMediator mediator;

        public ApplicationDbContext([NotNullAttribute] DbContextOptions options, IDateTime dateTime, ICurrentUserService currentUserService, IMediator mediator)
            : base(options)
        {
            this.dateTime = dateTime;
            this.currentUserService = currentUserService;
            this.mediator = mediator;
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            AuditEntities();
            await DispatchDomainEventsAsync();
            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrganisationConfiguration());
            modelBuilder.ApplyConfiguration(new PatientInviteConfiguration());
            modelBuilder.ApplyConfiguration(new PatientConfiguration());
            modelBuilder.ApplyConfiguration(new ClinicianConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        private void AuditEntities()
        {
            foreach (var entry in ChangeTracker.Entries<IAuditCreated>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property(nameof(IAuditCreated.CreatedById)).CurrentValue = currentUserService.UserId;
                    entry.Property(nameof(IAuditCreated.Created)).CurrentValue = dateTime.Now;
                    break;
                }
            }

            foreach (var entry in ChangeTracker.Entries<IAuditModified>())
            {
                if (entry.State == EntityState.Modified)
                {
                    entry.Property(nameof(IAuditModified.LastModifiedById)).CurrentValue = currentUserService.UserId;
                    entry.Property(nameof(IAuditModified.LastModifiedById)).CurrentValue = dateTime.Now;
                    break;
                }
            }
        }

        public async Task DispatchDomainEventsAsync()
        {
            var domainEntities = ChangeTracker
                .Entries<EntityBase>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.ClearDomainEvents());

            foreach (var domainEvent in domainEvents)
            {
                await mediator.Publish(domainEvent);
            }
        }

    }
}
