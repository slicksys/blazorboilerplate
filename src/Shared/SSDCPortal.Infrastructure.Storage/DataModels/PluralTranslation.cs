using SSDCPortal.Infrastructure.Storage.Permissions;
using SSDCPortal.Shared.DataInterfaces;
using System.ComponentModel.DataAnnotations;

namespace SSDCPortal.Infrastructure.Storage.DataModels
{
    [Permissions(Actions.Create | Actions.Update | Actions.Delete)]
    public class PluralTranslation : IPluralTranslation
    {
        [Key]
        public long Id { get; set; }

        public int Index { get; set; }

        [Required]
        public string Translation { get; set; }

        //Entity Framework generates the following key as shadow property https://docs.microsoft.com/en-us/ef/core/modeling/shadow-properties
        //Breeze Sharp DTO Entity needs this key. I explicitly add the key, so running SSDCPortal.EntityGenerator I have the right entity
        public long LocalizationRecordId { get; set; }

        [Required]
        public LocalizationRecord LocalizationRecord { get; set; }
        ILocalizationRecord IPluralTranslation.LocalizationRecord { get => LocalizationRecord; set => LocalizationRecord = (LocalizationRecord)value; }
    }
}
