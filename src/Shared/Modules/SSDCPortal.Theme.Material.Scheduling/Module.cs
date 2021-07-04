using Microsoft.Extensions.DependencyInjection;
using SSDCPortal.Shared.Interfaces;
using SSDCPortal.Shared.Models;

namespace SSDCPortal.Theme.Material.HR
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
            Init(services);
        }

        public override void ConfigureWebAssemblyServices(IServiceCollection services)
        {
            Init(services);
        }
    }
}
