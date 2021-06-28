using SSDCPortal.Shared.DataInterfaces;
using System.ComponentModel.DataAnnotations;

namespace SSDCPortal.Infrastructure.Storage.DataModels
{
    public class PluralFormRule : IPluralFormRule
    {
        [Key]
        [StringLength(5, MinimumLength = 2)]
        public string Language { get; set; }

        public int Count { get; set; }

        [Required]
        public string Selector { get; set; }
    }
}
