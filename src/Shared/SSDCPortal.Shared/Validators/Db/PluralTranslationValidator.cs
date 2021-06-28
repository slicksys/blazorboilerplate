using SSDCPortal.Shared.Dto.Db;
using SSDCPortal.Shared.Localizer;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace SSDCPortal.Shared.Validators.Db
{
    public class PluralTranslationValidator : LocalizedAbstractValidator<PluralTranslation>
    {
        public PluralTranslationValidator(IStringLocalizer<Global> l) : base(l)
        {
            RuleFor(p => p.Translation)
                .NotEmpty().WithName(L["Translation"]);
        }
    }
}
