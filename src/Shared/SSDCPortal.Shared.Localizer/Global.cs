﻿using System.Globalization;
using System.Threading;

namespace SSDCPortal.Shared.Localizer
{
    public class Global
    {
        public static string GetCountryName(string countryCode)
        {
            return new RegionInfo(Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName + "-" + countryCode).NativeName.Replace("Itàlia", "Italia");
        }
    }
}
