using SSDCPortal.Shared.Localizer;
using SSDCPortal.Shared.Validators;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace SSDCPortal.Shared.Models.Account.Validators
{
    public class ChangePasswordViewModelValidator<T> : LocalizedAbstractValidator<T> where T : ChangePasswordViewModel
    {
        public ChangePasswordViewModelValidator(IStringLocalizer<Global> l) : base(l)
        {
            RuleFor(p => p.UserId)
                .NotEmpty();

            RuleFor(p => p.Password).Password(L);

            RuleFor(p => p.PasswordConfirm)
                .Equal(p => p.Password).WithMessage(x => L["PasswordConfirmationFailed"]).WithName(L["ConfirmPassword"]);
        }
    }
}
