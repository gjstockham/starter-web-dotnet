namespace BPSample.Infrastructure.Configuration
{
    using Microsoft.Extensions.Configuration;

    public static class ConfigurationExtensions
    {
        public static TConfig GetCustomConfiguration<TConfig>(this IConfiguration configuration)
        {
            return configuration.GetSection(typeof(TConfig).Name).Get<TConfig>();
        }
    }
}
