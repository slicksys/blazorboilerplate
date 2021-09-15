using SSDCPortal.Shared.Interfaces;
using SSDCPortal.Shared.Models;
using SSDCPortal.Theme.Material.Demo.Shared.Components;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.DependencyInjection;
using Syncfusion;
using Syncfusion.Blazor;
using MudBlazor;
using MudBlazor.Services;


namespace SSDCPortal.Theme.Material.Demo
{
    public class Module : BaseModule
    {
        public override string Description => "SSDCPortal Sceduling";

        public override int Order => 2;

        private void Init(IServiceCollection services)
        {
            services.AddSingleton<IDynamicComponent, NavMenu>();
            services.AddSingleton<IDynamicComponent, Footer>();
            services.AddSingleton<IDynamicComponent, DrawerFooter>();
            services.AddSingleton<IDynamicComponent, TopRightBarSection>();
          
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddMudServices();
            services.AddSyncfusionBlazor();
            Init(services);
        }

        public override void ConfigureWebAssemblyServices(IServiceCollection services)
        {
            Init(services);
        }
    }
}
