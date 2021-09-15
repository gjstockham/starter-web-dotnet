namespace BPSample.WebUI.Authentication
{
    using BPSample.Application.Common.Interfaces;
    using BPSample.Infrastructure.Configuration;
    using BPSample.WebUI.Authentication.Services;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Authentication.OpenIdConnect;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using System;
    using System.IdentityModel.Tokens.Jwt;

    public static class AuthenticationStartup
    {
        public static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
        {
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            var authenticationSettings = configuration.GetCustomConfiguration<AuthenticationSettings>();

            services.ConfigureApplicationCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromMinutes(15);
            });

            services.AddSession(options =>
            {
                options.Cookie.HttpOnly = false;
                options.Cookie.IsEssential = true;
                options.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.Always;
            });

            services.AddAuthentication(options =>
                {
                    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
                })
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
                {
                    options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;

                    options.Authority = authenticationSettings.Authority;
                    options.RequireHttpsMetadata = true;

                    options.ClientId = authenticationSettings.ClientId;
                    options.ClientSecret = authenticationSettings.ClientSecret;
                    options.SaveTokens = true;

                    options.ResponseType = "id_token code";
                });

            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<ICurrentOrganisationService, CurrentOrganisationService>();

            return services;
        }

    }
}
