using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace SSDCPortal.Theme.Material
{
    public abstract class ComponentBase //: Microsoft.AspNetCore.Components.ComponentBase, IDisposable
    {
        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }

        [Inject] protected NavigationManager NavigationManager { get; set; }
        [Inject] protected IJSRuntime JsRuntime { get; set; }

        private CancellationTokenSource CancelTokenSource = new CancellationTokenSource();
        private CancellationToken CancelToken;

        protected CancellationToken getCancellationToken(int msDelay = -1)
        {
            if (CancelTokenSource != null)
            {
                CancelTokenSource.Dispose();
            }
            if (this.disposing)
                throw new OperationCanceledException();

            CancelTokenSource = new CancellationTokenSource(msDelay);
            CancelToken = CancelTokenSource.Token;
            
            if (this.disposing)
                throw new OperationCanceledException();
            
            return CancelToken;
        }
        
        private bool inproc;
        
        protected bool EventProcessing { get => inproc || disposing; set => inproc = value; }

        protected new void StateHasChanged()
        {
            if (this.disposing) return;
            base.StateHasChanged();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls
        private bool disposing = false;

        protected abstract void Dispose();

        protected void Dispose(bool disposing)
        {
            if (!this.disposing)
            {
                this.disposing = true;
                this.EventProcessing = true;
            }

            if (CancelTokenSource != null)
            {
                try
                {
                    CancelTokenSource.Cancel();
                    CancelTokenSource.Dispose();
                }
                catch (Exception ex) { }
                finally { CancelTokenSource = null; }
            }

            if (!disposedValue)
            {
                //if (disposing)
                //{
                //    // TODO: dispose managed state (managed objects).
                //}

                //// TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                //// TODO: set large fields to null.

                //if (exHandler != null)
                //{
                //    exHandler.Dispose();
                //    exHandler = null;
                //}

                //Dispose();
                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~ComponentBase()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion

    }
}
