using SSDCPortal.Shared.Localizer;
using Microsoft.Extensions.Localization;

namespace SSDCPortal.Shared.Models.Account.Validators
{
    public class LoginViewModelValidator : LoginInputModelValidator<LoginViewModel>
    {
        public LoginViewModelValidator(IStringLocalizer<Global> l) : base(l)
        {
        }
    }
}
