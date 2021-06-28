using SSDCPortal.Shared.Localizer;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace SSDCPortal.Shared.Models.Account.Validators
{
    public class ResetPasswordViewModelValidator : ChangePasswordViewModelValidator<ResetPasswordViewModel>
    {
        public ResetPasswordViewModelValidator(IStringLocalizer<Global> l) : base(l)
        {
            RuleFor(p => p.Token)
                .NotEmpty().WithName(L["RecoveryCode"]);
        }
    }
}
