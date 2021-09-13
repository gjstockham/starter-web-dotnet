namespace BPSample.WebUI
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using BPSample.Application;
    using BPSample.Infrastructure;
    using BPSample.WebUI.Logging;
    using BPSample.WebUI.Authentication;
    using BPSample.WebUI.Authorization;
    using BPSample.Infrastructure.Persistence;
    using BPSample.WebUI.Security;

    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication();
            services.AddInfrastructure(Configuration, Environment);
            services.AddSecurity(Configuration, Environment);
            services.AddHttpContextAccessor();
            services.AddHealthChecks().AddDbContextCheck<ApplicationDbContext>();
            services.AddAuthentication(Configuration, Environment);
            services.AddAuthorization(Configuration, Environment);
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseEnhancedRequestLogging();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSecurity();
            app.UseHealthChecks("/health");
            app.UseRouting();
            app.UseInfrastructure();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
