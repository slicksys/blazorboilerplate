﻿using SSDCPortal.Shared.Interfaces;
//using MatBlazor;
using MudBlazor;

namespace SSDCPortal.Theme.Material.Services
{
    public interface IViewNotifier{}

    public class ViewNotifier : IViewNotifier
    {
        //private readonly IMatToaster matToaster;
        //public ViewNotifier(IMatToaster matToaster)
        //{
        //    this.matToaster = matToaster;
        //}
        //public void Show(string message, ViewNotifierType type, string title = null, string icon = null)
        //{
        //    var matType = MatToastType.Success;
        //
        //    switch (type)
        //    {
        //        case ViewNotifierType.Error:
        //            matType = MatToastType.Danger;
        //            break;
        //        case ViewNotifierType.Warning:
        //            matType = MatToastType.Warning;
        //            break;
        //        case ViewNotifierType.Info:
        //            matType = MatToastType.Info;
        //            break;
        //    }
        //
        //    matToaster.Add(message, matType, title, icon);
        //}
    }
}
