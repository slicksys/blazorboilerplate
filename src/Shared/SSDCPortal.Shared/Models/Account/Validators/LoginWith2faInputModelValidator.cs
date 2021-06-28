using SSDCPortal.Shared.Localizer;
using SSDCPortal.Shared.Validators;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace SSDCPortal.Shared.Models.Account.Validators
{
    public class LoginWith2faInputModelValidator : LocalizedAbstractValidator<LoginWith2faInputModel>
    {
        public LoginWith2faInputModelValidator(IStringLocalizer<Global> l) : base(l)
        {
            RuleFor(p => p.TwoFactorCode)
                .NotEmpty()
                .Length(6, 7).WithName(L["AuthenticatorCode"]);
        }
    }
}
