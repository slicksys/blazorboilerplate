using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSDCPortal.Theme.Material.Demo.Pages
{
   public class KennelSchedulerPage : ComponentBase
    {
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (!firstRender) return;
            try
            {
                EventProcessing = true;
                var ct = getCancellationToken();

            
                Console.WriteLine("Finished OnAfterRenderAsync");


                StateHasChanged();
            }
            catch (OperationCanceledException) { }
            catch (Exception ex) { Console.WriteLine(ex); }
            finally { EventProcessing = false; }
        }

        protected override void Dispose()
        {
            base.Dispose(true);
        }
    }
}
