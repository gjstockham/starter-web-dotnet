namespace BPSample.WebUI.Authorization
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public static class AuthorizationStartup
    {
        public static IServiceCollection AddAuthorization(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
        {
            services.AddAuthorization(options =>
            {
                options.FallbackPolicy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
            });

            return services;
        }
    }
}
