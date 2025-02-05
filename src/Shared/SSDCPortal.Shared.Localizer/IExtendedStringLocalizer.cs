﻿using Microsoft.Extensions.Localization;
using System.Globalization;

namespace SSDCPortal.Shared.Localizer
{
    public interface IExtendedStringLocalizer : IStringLocalizer
    {
        bool TryGetTranslation(string name, object[] arguments, out string value);
        IExtendedStringLocalizer WithCulture(CultureInfo culture);
    }
}
