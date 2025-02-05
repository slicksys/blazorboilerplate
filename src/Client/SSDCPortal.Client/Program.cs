﻿using SSDCPortal.Infrastructure.AuthorizationDefinitions;
using SSDCPortal.Shared.Extensions;
using SSDCPortal.Shared.Interfaces;
using SSDCPortal.Shared.Localizer;
using SSDCPortal.Shared.Providers;
using SSDCPortal.Shared.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using System;
using System.Globalization;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using MudBlazor.Services;

namespace SSDCPortal.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            //TODO see what oqtane does
            var baseModule = new Theme.Material.Module();
            // var schedModule = new Scheduler.Admin.Module();
            var adminModule = new Theme.Material.Admin.Module();
            // var demoModule = new Theme.Material.Demo.Module();

            Assembly[] allAssemblies = AppDomain.CurrentDomain.GetAssemblies();

            ModuleProvider.Init(allAssemblies);

            builder.RootComponents.AddRange(new[] { ModuleProvider.RootComponentMapping });

            builder.Services.AddSingleton<ILocalizationProvider, LocalizationProvider>();
            builder.Services.AddTextLocalization(options =>
            {
                options.ReturnOnlyKeyIfNotFound = !builder.HostEnvironment.IsDevelopment();
                options.FallBackNeutralCulture = !builder.HostEnvironment.IsDevelopment(); 
            });
            builder.Services.AddDataProtection().SetApplicationName(nameof(SSDCPortal));
            builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddAuthorizationCore();
            builder.Services.AddSingleton<IAuthorizationPolicyProvider, SharedAuthorizationPolicyProvider>();
            builder.Services.AddTransient<IAuthorizationHandler, DomainRequirementHandler>();
            builder.Services.AddScoped<AuthenticationStateProvider, IdentityAuthenticationStateProvider>();

            builder.Services.AddScoped<ILocalizationApiClient, LocalizationApiClient>();
            builder.Services.AddScoped<IAccountApiClient, AccountApiClient>();
            builder.Services.AddScoped<AppState>();
            builder.Services.AddScoped<IApiClient, ApiClient>();
            builder.Services.AddMudServices();

            foreach (var module in ModuleProvider.Modules)
                module.ConfigureWebAssemblyServices(builder.Services);

            var host = builder.Build();

            foreach (var module in ModuleProvider.Modules)
                module.ConfigureWebAssemblyHost(host);

            using (var serviceScope = host.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var js = serviceScope.ServiceProvider.GetService<IJSRuntime>();
                var cookieCulture = await js.GetAspNetCoreCultureCookie();

                if (!string.IsNullOrWhiteSpace(cookieCulture))
                {
                    CultureInfo.DefaultThreadCurrentCulture = new CultureInfo(cookieCulture);
                    CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.CurrentCulture;
                }

                var localizationApiClient = serviceScope.ServiceProvider.GetService<ILocalizationApiClient>();

                var localizationProvider = serviceScope.ServiceProvider.GetService<ILocalizationProvider>();

                var localizationRecordsTask = localizationApiClient.GetLocalizationRecords();

                var pluralFormRulesTask = localizationApiClient.GetPluralFormRules();

                await Task.WhenAll(new Task[] { localizationRecordsTask, pluralFormRulesTask });

                localizationProvider.Init(localizationRecordsTask.Result, pluralFormRulesTask.Result);
            }

            await host.RunAsync();
        }
    }
}
