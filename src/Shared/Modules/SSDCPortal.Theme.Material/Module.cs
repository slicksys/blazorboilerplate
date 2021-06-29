using SSDCPortal.Shared.Interfaces;
using SSDCPortal.Theme.Material.Services;
using SSDCPortal.Theme.Material.TagHelpers;
using MatBlazor;
using MudBlazor;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using Toolbelt.Blazor.Extensions.DependencyInjection;
using Syncfusion;
using MudBlazor.Services;

namespace SSDCPortal.Theme.Material
{
    public class Module : IModule, ITheme
    {
        public Module()
        {
            RootComponentMapping = new RootComponentMapping(typeof(App), "app");
        }

        public RootComponentMapping RootComponentMapping { get; }

        public string Name => "MatBlazor default theme";

        public string Description => "MatBlazor default theme";

        public int Order => 1;

        public void ConfigureServices(IServiceCollection services)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NDIyNzQ0QDMxMzkyZTMxMmUzMG5HZ25LN1hzSW5ITWlIb1dHNjM5RTlhM3k1S0ErVk9IY2xEd3Y5TzhSLzg9");
            services.AddTransient<ITagHelperComponent, ThemeTagHelperComponent>();
            services.AddTransient<ITagHelperComponent, AppTagHelperComponent>();

            services.AddMatToaster(config =>
            {
                config.Position = MatToastPosition.BottomRight;
                config.PreventDuplicates = true;
                config.NewestOnTop = true;
                config.ShowCloseButton = true;
                config.MaximumOpacity = 95;
                config.VisibleStateDuration = 3000;
            });
            
            services.AddMudServices();


            services.AddScoped<IViewNotifier, ViewNotifier>();
        }

        public void ConfigureWebAssemblyServices(IServiceCollection services)
        {
            services.AddLoadingBar();
            services.AddMatToaster(config =>
            {
                config.Position = MatToastPosition.BottomRight;
                config.PreventDuplicates = true;
                config.NewestOnTop = true;
                config.ShowCloseButton = true;
                config.MaximumOpacity = 95;
                config.VisibleStateDuration = 3000;
            });

            services.AddScoped<IViewNotifier, ViewNotifier>();

            var sp = services.BuildServiceProvider();
            
            sp.GetRequiredService<HttpClient>().EnableIntercept(sp);
        }

        public void ConfigureWebAssemblyHost(WebAssemblyHost webAssemblyHost)
        {
            webAssemblyHost.UseLoadingBar();
        }
    }
}
