﻿using SSDCPortal.Infrastructure.Server;
using SSDCPortal.Infrastructure.Server.Models;
using SSDCPortal.Shared.Localizer;
using SSDCPortal.Shared.Dto.Email;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Threading.Tasks;
using static Microsoft.AspNetCore.Http.StatusCodes;
using SSDCPortal.Server.Aop;

namespace SSDCPortal.Server.Controllers
{
    [ApiResponseException]
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailManager _emailManager;
        private readonly IStringLocalizer<Global> L;

        public EmailController(IEmailManager emailManager, IStringLocalizer<Global> l)
        {
            _emailManager = emailManager;
            L = l;
        }

        [HttpPost]
        [ProducesResponseType(Status200OK)]
        [ProducesResponseType(Status400BadRequest)]
        public async Task<ApiResponse> SendTestEmail([FromBody] EmailDto parameters)
            => ModelState.IsValid ?
                await _emailManager.SendTestEmail(parameters) :
                new ApiResponse(Status400BadRequest, L["InvalidData"]);

        public async Task<ApiResponse> Receive()
            => await _emailManager.ReceiveMailImapAsync();
    }
}
