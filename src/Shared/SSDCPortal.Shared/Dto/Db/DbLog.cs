using SSDCPortal.Shared.Helpers;
using System.Collections.Generic;

namespace SSDCPortal.Shared.Dto.Db
{
    public partial class DbLog
    {
        public IDictionary<string, string> LogProperties
        {
            get
            {
                return RegexUtilities.DirtyXmlPropertyParser(Properties);
            }
        }

    }
}
