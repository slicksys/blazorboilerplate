using SSDCPortal.Shared.Models;


using SSDCPortal.Shared.Interfaces;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.DependencyInjection;
using Syncfusion;
using Syncfusion.Blazor;
using MudBlazor;
using MudBlazor.Services;



namespace SSDCPortal.Theme.Material.Admin
{
    public class Module : BaseModule
    {
        private void Init(IServiceCollection services)
        {
            services.AddSingleton<IDynamicComponent, NavMenu>();
            services.AddSingleton<IDynamicComponent, Footer>();
            services.AddSingleton<IDynamicComponent, DrawerFooter>();
            services.AddSingleton<IDynamicComponent, TopRightBarSection>();

        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddSyncfusionBlazor();
            services.AddMudServices();
            Init(services);
        }

        public override void ConfigureWebAssemblyServices(IServiceCollection services)
        {
            Init(services);
        }
    }
}
