//Autogenerated by SSDCPortal.EntityGenerator
using SSDCPortal.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SSDCPortal.Shared.DataInterfaces
{
    public interface ILocalizationRecord
    {
        Int64 Id { get; set; }

        String MsgId { get; set; }

        String MsgIdPlural { get; set; }

        String Translation { get; set; }

        String Culture { get; set; }

        String ContextId { get; set; }

        ICollection<IPluralTranslation> PluralTranslations { get; }

    }
}
