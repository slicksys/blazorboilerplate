using SSDCPortal.Shared.Localizer;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace SSDCPortal.Shared.Validators
{
    public class LocalizedAbstractValidator<T> : AbstractValidator<T>
    {
        protected readonly IStringLocalizer<Global> L;
        public LocalizedAbstractValidator(IStringLocalizer<Global> l)
        {
            L = l;
        }
    }
}
