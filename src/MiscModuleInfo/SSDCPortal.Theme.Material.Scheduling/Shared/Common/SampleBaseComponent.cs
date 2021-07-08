using Microsoft.AspNetCore.Components;

namespace SSDCPortal.Theme.Material.Demo.Shared.Common
{
    /// <summary>
    /// A base component to perform common functionalities.
    /// </summary>
    public class SampleBaseComponent: ComponentBase
    {
        [Inject]
        protected SampleService SampleService { get; set; }

        protected override void Dispose()
        {

        }

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            SampleService.Spinner?.Hide();
            SampleService.Spinner?.ShowModalSpinner(false);
        }
    }
}
