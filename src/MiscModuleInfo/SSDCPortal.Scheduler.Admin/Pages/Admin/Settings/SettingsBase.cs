﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using SSDCPortal.Constants;
using SSDCPortal.Infrastructure.AuthorizationDefinitions;
using SSDCPortal.Shared.Dto.Db;
using SSDCPortal.Shared.Interfaces;
using SSDCPortal.Shared.Localizer;

namespace SSDCPortal.Scheduler.Admin.Pages.Admin.Settings
{
    [Authorize(Policies.IsAdmin)]
    [Layout(typeof(AdminLayout))]
    public abstract class SettingsBase : ComponentBase
    {
        protected Dictionary<SettingKey, TenantSetting> settings;

        [Inject] private NavigationManager navigationManager { get; set; }

        [Inject] protected IApiClient apiClient { get; set; }

        [Inject] protected IViewNotifier viewNotifier { get; set; }

        [Inject] protected IStringLocalizer<Global> L { get; set; }

        protected async Task LoadSettings(string prefix)
        {
            try
            {
                var result = (await apiClient.GetTenantSettings()).Where(i => i.Key.ToString().StartsWith(prefix)).ToDictionary(i => i.Key, i => i);

                foreach (var def in TenantSettingValues.Default.Where(i => i.Key.ToString().StartsWith(prefix)))
                {
                    if (!result.ContainsKey(def.Key))
                    {
                        var entity = new TenantSetting() { Key = def.Key, Type = def.Value.Item2, Value = def.Value.Item1 };
                        result.Add(def.Key, entity);
                        apiClient.AddEntity(entity);
                    }
                }

                settings = result;
            }
            catch (Exception ex)
            {
                viewNotifier.Show(ex.GetBaseException().Message, ViewNotifierType.Error, L["Operation Failed"]);
            }
        }

        protected async Task SaveChanges()
        {
            try
            {
                var reload = false;

                if (settings.ContainsKey(SettingKey.MainConfiguration_Runtime) && settings[SettingKey.MainConfiguration_Runtime].EntityAspect.HasChanges())
                    reload = true;

                await apiClient.SaveChanges();

                viewNotifier.Show(L["Operation Successful"], ViewNotifierType.Success);

                if (reload)
                    navigationManager.NavigateTo(navigationManager.Uri, true);

            }
            catch (Exception ex)
            {
                viewNotifier.Show(ex.GetBaseException().Message, ViewNotifierType.Error, L["Operation Failed"]);
            }
        }
    }
}
