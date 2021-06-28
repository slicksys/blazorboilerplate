using SSDCPortal.Shared.Localizer;
using SSDCPortal.Shared.Validators;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace SSDCPortal.Shared.Models.Account.Validators
{
    public class ForgotPasswordViewModelValidator : LocalizedAbstractValidator<ForgotPasswordViewModel>
    {
        public ForgotPasswordViewModelValidator(IStringLocalizer<Global> l) : base(l)
        {
            RuleFor(p => p.Email)
                .NotEmpty()
                .EmailAddress().WithName(L["Email"]);
        }
    }
}
