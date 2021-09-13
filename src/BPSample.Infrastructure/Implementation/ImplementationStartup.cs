namespace BPSample.Infrastructure.Implementation
{
    using BPSample.Application.Common.Interfaces;
    using BPSample.Application.Common.Interfaces.Data;
    using BPSample.Infrastructure.Implementation.Data;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public static class ImplementationStartup
    {
        public static IServiceCollection AddImplementation(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
        {
            services.AddScoped<IOrganisationRepository, OrganisationRepository>();
            services.AddScoped<IPatientInviteRepository, PatientInviteRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IClinicianRepository, ClinicianRepository>();

            services.AddTransient<IDateTime, DateTimeService>();

            return services;
        }
    }
}
