using SSDCPortal.Infrastructure.Server.Models;
using SSDCPortal.Shared.Dto.Email;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SSDCPortal.Infrastructure.Server
{
    public interface IEmailManager
    {
        Task<ApiResponse> SendTestEmail(EmailDto parameters);
        Task<ApiResponse> Receive();
        Task<ApiResponse> SendEmailAsync(EmailMessageDto emailMessage);
        List<EmailMessageDto> ReceiveEmail(int maxCount = 10);
        Task<ApiResponse> ReceiveMailImapAsync();
        Task<ApiResponse> ReceiveMailPopAsync(int min = 0, int max = 0);
    }
}