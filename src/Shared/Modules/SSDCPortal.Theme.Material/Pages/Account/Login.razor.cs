using System;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace SSDCPortal.Theme.Material
{
    public class LoginBase //: ComponentBase
    {
        public string wow { get; set; }
        protected override void OnInitialized()
        {
            try
            {
                base.OnInitialized();
                var ct = getCancellationToken();
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (!firstRender) return;
            try
            {
                EventProcessing = true;
                var ct = getCancellationToken();
              
                StateHasChanged();
            }
            catch (OperationCanceledException) { }
            catch (Exception ex) { Console.WriteLine(ex); }
            finally{ EventProcessing = false; }
        }

        protected override void Dispose()
        {
            base.Dispose(true);
        }

    }
}