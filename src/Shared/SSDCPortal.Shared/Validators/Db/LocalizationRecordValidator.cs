using SSDCPortal.Shared.Dto.Db;
using SSDCPortal.Shared.Localizer;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace SSDCPortal.Shared.Validators.Db
{
    public class LocalizationRecordValidator : LocalizedAbstractValidator<LocalizationRecord>
    {
        public LocalizationRecordValidator(IStringLocalizer<Global> l) : base(l)
        {
            RuleFor(p => p.ContextId)
                .NotEmpty().WithName(L["ContextId"]);

            RuleFor(p => p.MsgId)
                .NotEmpty().WithName(L["MsgId"]);

            RuleFor(p => p.Translation)
                .NotEmpty().WithName(L["Translation"]);
        }
    }
}
