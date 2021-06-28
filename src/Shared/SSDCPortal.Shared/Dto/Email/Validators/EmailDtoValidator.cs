using SSDCPortal.Shared.Localizer;
using SSDCPortal.Shared.Validators;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace SSDCPortal.Shared.Dto.Email.Validators
{
    public class EmailDtoValidator : LocalizedAbstractValidator<EmailDto>
    {
        public EmailDtoValidator(IStringLocalizer<Global> l) : base(l)
        {
            RuleFor(p => p.ToAddress)
                .NotEmpty()
                .EmailAddress().WithName(L["Email"]);
        }
    }
}
