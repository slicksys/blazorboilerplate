﻿using SSDCPortal.Shared.Dto.Db;
using SSDCPortal.Shared.Interfaces;
using SSDCPortal.Shared.Localizer;
using Karambolo.Common.Localization;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSDCPortal.Theme.Material.Admin.Pages.Admin
{
    public class PluralizationRulesPage : ComponentBase
    {
        [Inject] IViewNotifier viewNotifier { get; set; }
        [Inject] ILocalizationApiClient localizationApiClient { get; set; }
        [Inject] protected IStringLocalizer<Global> L { get; set; }

        protected List<PluralFormRule> PluralFormRules { get; set; }
        protected List<string> LocalizationCultures { get; set; } = new List<string>();
        protected PluralFormRule currentPluralFormRule { get; set; } = new PluralFormRule();
        protected PluralFormRule newPluralFormRule { get; set; } = new PluralFormRule();

        protected override async Task OnInitializedAsync()
        {
            await LoadPluralFormRules();
        }
        protected async Task LoadPluralFormRules()
        {
            PluralFormRules = new List<PluralFormRule>();

            try
            {
                localizationApiClient.ClearEntitiesCache();
                var result = await localizationApiClient.GetPluralFormRules();
                PluralFormRules = new List<PluralFormRule>(result);

                LocalizationCultures.Clear();

                LocalizationCultures.AddRange(SSDCPortal.Shared.Localizer.Settings.SupportedCultures
                    .Where(i => !PluralFormRules.Any(l => l.Language == i)));

                viewNotifier.Show(L["One item found", Plural.From("{0} items found", PluralFormRules.Count)], ViewNotifierType.Success, L["Operation Successful"]);
            }
            catch (Exception ex)
            {
                viewNotifier.Show(ex.GetBaseException().Message, ViewNotifierType.Error, L["Operation Failed"]);
            }
        }
        protected async Task OpenDelete(PluralFormRule pluralFormRule)
        {
            localizationApiClient.RemoveEntity(pluralFormRule);

            if (await SaveChanges())
            {
                newPluralFormRule = new PluralFormRule();
                await LoadPluralFormRules();
            }
        }
        protected async Task<bool> SaveChanges()
        {
            var result = true;

            try
            {
                await localizationApiClient.SaveChanges();

                viewNotifier.Show(L["Operation Successful"], ViewNotifierType.Success);
            }
            catch (Exception ex)
            {
                result = false;
                viewNotifier.Show(ex.GetBaseException().Message, ViewNotifierType.Error, L["Operation Failed"]);
            }

            return result;
        }

        protected void CancelChanges()
        {
            localizationApiClient.CancelChanges();
        }

        protected async Task SaveNewPluralFormRule()
        {
            localizationApiClient.AddEntity(newPluralFormRule);

            if (await SaveChanges())
            {
                newPluralFormRule = new PluralFormRule();
                await LoadPluralFormRules();
            }
        }
    }
}
