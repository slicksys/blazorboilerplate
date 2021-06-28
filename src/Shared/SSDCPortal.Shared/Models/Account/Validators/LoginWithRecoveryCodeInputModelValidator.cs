using SSDCPortal.Shared.Localizer;
using SSDCPortal.Shared.Validators;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace SSDCPortal.Shared.Models.Account.Validators
{
    public class LoginWithRecoveryCodeInputModelValidator : LocalizedAbstractValidator<LoginWithRecoveryCodeInputModel>
    {
        public LoginWithRecoveryCodeInputModelValidator(IStringLocalizer<Global> l) : base(l)
        {
            RuleFor(p => p.RecoveryCode)
                .NotEmpty().WithName(L["RecoveryCode"]);
        }
    }
}
