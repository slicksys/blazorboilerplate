﻿using SSDCPortal.Shared.Localizer;
using SSDCPortal.Shared.Validators;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace SSDCPortal.Shared.Models.Account.Validators
{
    public class LoginInputModelValidator<T> : LocalizedAbstractValidator<T> where T : LoginInputModel
    {
        public LoginInputModelValidator(IStringLocalizer<Global> l) : base(l)
        {
            RuleFor(p => p.UserName)
                .NotEmpty()
                .Matches(@"^[^\s]+$").WithMessage(x => L["SpacesNotPermitted"])
                .Length(2, 64).WithName(L["UserName"]);

            RuleFor(p => p.Password).Password(L);
        }
    }
}
