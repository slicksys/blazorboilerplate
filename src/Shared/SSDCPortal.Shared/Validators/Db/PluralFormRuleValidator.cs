﻿using SSDCPortal.Shared.Dto.Db;
using SSDCPortal.Shared.Localizer;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace SSDCPortal.Shared.Validators.Db
{
    public class PluralFormRuleValidator : LocalizedAbstractValidator<PluralFormRule>
    {
        public PluralFormRuleValidator(IStringLocalizer<Global> l) : base(l)
        {
            RuleFor(p => p.Language)
                .NotEmpty().WithName(L["Culture"]);

            RuleFor(p => p.Count)
                .GreaterThan(0).WithName(L["Count"]);

            RuleFor(p => p.Selector)
                .NotEmpty().WithName(L["Selector"]);
        }
    }
}
