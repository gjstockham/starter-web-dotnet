namespace BPSample.WebUI.Logging
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Hosting;
    using Serilog;

    public static class LoggingStartup
    {
        public static IWebHostBuilder AddSerilog(this IWebHostBuilder webBuilder)
        {
            webBuilder.UseSerilog((context, config) =>
            {
                config
                    .MinimumLevel.Information()
                    .Enrich.FromLogContext();

                if (context.HostingEnvironment.IsDevelopment())
                {
                    config
                        .WriteTo.Console()
                        .WriteTo.Debug();
                }
                else
                {
                    config
                        .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning);
                }
            });

            return webBuilder;
        }

        public static IApplicationBuilder UseEnhancedRequestLogging(this IApplicationBuilder appBuilder)
        {
            return appBuilder
                .UseSerilogRequestLogging();
        }

    }
}
