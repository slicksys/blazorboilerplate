﻿using SSDCPortal.Infrastructure.Server;
using SSDCPortal.Shared.Models.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace SSDCPortal.Server.Pages
{
    [Authorize]
    public class LogoutModel : PageModel
    {
        private readonly IAccountManager _accountManager;

        public LogoutModel(IAccountManager accountManager)
        {
            _accountManager = accountManager;
        }
        public async Task<IActionResult> OnPostAsync(AccountFormModel model)
        {
            await _accountManager.Logout(User);

            return LocalRedirect(Url.Content($"~{model.ReturnUrl}"));
        }
    }
}