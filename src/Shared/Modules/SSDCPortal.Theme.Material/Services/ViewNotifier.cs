using System;
using System.Collections;
using SSDCPortal.Shared.Interfaces;
//using MatBlazor;
using MudBlazor;

namespace SSDCPortal.Theme.Material.Services
{
    public class ViewNotifier : IViewNotifier
    {
        private String DisplayIcon { get; set; }
        private readonly ISnackbar mudSnack;
        public ViewNotifier(ISnackbar mudSnack)
        {
            this.mudSnack = mudSnack;
        }
        public void Show(string message, ViewNotifierType type, string title = null, string displayIcon = "")
        {
            DisplayIcon = displayIcon;
            Severity sv;
            switch (type)
            {
                case ViewNotifierType.Error:
                    sv = Severity.Error;
                    break;
                case ViewNotifierType.Warning:
                    sv = Severity.Warning;
                    break;
                case ViewNotifierType.Info:
                    sv = Severity.Info;
                    break;
                case ViewNotifierType.Success:
                    sv = Severity.Success;
                    break;
               default:
                    sv = Severity.Normal;
                   break;
            }

            mudSnack.Add(message, sv, config =>
            {
                config.ShowCloseIcon = true;
                config.SnackbarVariant = Variant.Filled;
                config.ActionColor = Color.Error;
                config.Icon = DisplayIcon;
            });
        }
    }
}
