using Karambolo.PO;
using System.Globalization;

namespace SSDCPortal.Shared.Localizer
{
    public static class POCatalogExtensions
    {
        public static string GetCultureName(this POCatalog catalogo) => new CultureInfo(catalogo.Language.Replace("_", "-")).Name;
    }
}
