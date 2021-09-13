namespace BPSample.WebUI
{
    using BPSample.WebUI.Logging;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Hosting;

    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            // DB Seeding here if required?

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.AddSerilog();
                    webBuilder.UseKestrel(options =>
                    {
                        options.AddServerHeader = false;
                        options.ConfigureHttpsDefaults(https =>
                        {
                            https.SslProtocols = System.Security.Authentication.SslProtocols.Tls12 | System.Security.Authentication.SslProtocols.Tls13;
                        });
                    });
                    webBuilder.UseStartup<Startup>();
                });
    }
}
