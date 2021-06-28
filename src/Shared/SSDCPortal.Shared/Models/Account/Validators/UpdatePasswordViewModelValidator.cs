using SSDCPortal.Shared.Localizer;
using SSDCPortal.Shared.Validators;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace SSDCPortal.Shared.Models.Account.Validators
{
    public class UpdatePasswordViewModelValidator : LocalizedAbstractValidator<UpdatePasswordViewModel>
    {
        public UpdatePasswordViewModelValidator(IStringLocalizer<Global> l) : base(l)
        {
            RuleFor(p => p.NewPassword).Password(L);

            RuleFor(p => p.NewPasswordConfirm)
                .Equal(p => p.NewPassword).WithMessage(x => L["PasswordConfirmationFailed"]).WithName(L["ConfirmPassword"]);

            RuleFor(p => p.CurrentPassword)
                .NotEmpty()
                .Length(6, 100).WithName(L["Password"]);
        }
    }
}
