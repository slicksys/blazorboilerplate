﻿using SSDCPortal.Infrastructure.Server;
using SSDCPortal.Infrastructure.Server.Models;
using SSDCPortal.Server.Aop;
using SSDCPortal.Shared.Dto.Email;
using SSDCPortal.Shared.Models;
using MailKit.Net.Imap;
using MailKit.Net.Pop3;
using MailKit.Net.Smtp;
using MailKit.Search;
using Microsoft.Extensions.Logging;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace SSDCPortal.Server.Managers
{
    [ApiResponseException]
    public class EmailManager : IEmailManager
    {
        private EmailConfiguration _emailConfiguration;
        private readonly IEmailFactory _emailFactory;
        private readonly ILogger<EmailManager> _logger;

        public EmailManager(ITenantSettings<EmailConfiguration> emailConfiguration, IEmailFactory emailFactory, ILogger<EmailManager> logger)
        {
            _emailConfiguration = emailConfiguration.Value;
            _emailFactory = emailFactory;
            _logger = logger;
        }

        //Used by API
        public async Task<ApiResponse> SendTestEmail(EmailDto parameters)
        {
            EmailMessageDto email = _emailFactory.BuildTestEmail(parameters.ToName);
            email.ToAddresses.Add(new EmailAddressDto(parameters.ToName, parameters.ToAddress));

            return await SendEmailAsync(email);
        }

        public Task<ApiResponse> Receive()
        {
            throw new NotImplementedException();
        }

        public List<EmailMessageDto> ReceiveEmail(int maxCount = 10)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse> ReceiveMailImapAsync()
        {
            using (var emailClient = new ImapClient())
            {
                // use this if you need to specify using ssl; MailKit should usually be able to autodetect the appropriate settings
                // await emailClient.ConnectAsync(_emailConfiguration.ImapServer, _emailConfiguration.ImapPort, _emailConfiguration.ImapUseSSL);

                await emailClient.ConnectAsync(_emailConfiguration.ImapServer, _emailConfiguration.ImapPort);

                emailClient.AuthenticationMechanisms.Remove("XOAUTH2");


                if (!string.IsNullOrWhiteSpace(_emailConfiguration.ImapUsername))
                {
                    await emailClient.AuthenticateAsync(_emailConfiguration.ImapUsername, _emailConfiguration.ImapPassword);
                }

                List<EmailMessageDto> emails = new List<EmailMessageDto>();
                await emailClient.Inbox.OpenAsync(MailKit.FolderAccess.ReadOnly);

                //TODO implement email results filtering
                var uids = await emailClient.Inbox.SearchAsync(SearchQuery.All);
                foreach (var uid in uids)
                {
                    var message = await emailClient.Inbox.GetMessageAsync(uid);

                    var emailMessage = new EmailMessageDto
                    {
                        Body = !string.IsNullOrEmpty(message.HtmlBody) ? message.HtmlBody : message.TextBody,

                        Subject = message.Subject
                    };
                    emailMessage.ToAddresses.AddRange(message.To.Select(x => (MailboxAddress)x).Select(x => new EmailAddressDto(x.Name, x.Address)));
                    emailMessage.FromAddresses.AddRange(message.From.Select(x => (MailboxAddress)x).Select(x => new EmailAddressDto(x.Name, x.Address)));

                    emails.Add(emailMessage);
                }

                await emailClient.DisconnectAsync(true);
                return new ApiResponse(Status200OK, null, emails);
            }
        }

        public async Task<ApiResponse> ReceiveMailPopAsync(int min = 0, int max = 0)
        {
            using (var emailClient = new Pop3Client())
            {
                await emailClient.ConnectAsync(_emailConfiguration.PopServer, _emailConfiguration.PopPort);     // omitting usessl to allow mailkit to autoconfigure

                emailClient.AuthenticationMechanisms.Remove("XOAUTH2");

                if (!String.IsNullOrWhiteSpace(_emailConfiguration.PopUsername))
                {
                    await emailClient.AuthenticateAsync(_emailConfiguration.PopUsername, _emailConfiguration.PopPassword);
                }

                List<EmailMessageDto> emails = new List<EmailMessageDto>();

                if (max == 0) max = await emailClient.GetMessageCountAsync(); // if max not defined, get all messages

                for (int i = min; i < max; i++)
                {
                    var message = await emailClient.GetMessageAsync(i);

                    var emailMessage = new EmailMessageDto
                    {
                        Body = !string.IsNullOrEmpty(message.HtmlBody) ? message.HtmlBody : message.TextBody,
                        IsHtml = !string.IsNullOrEmpty(message.HtmlBody) ? true : false,
                        Subject = message.Subject

                    };
                    emailMessage.ToAddresses.AddRange(message.To.Select(x => (MailboxAddress)x).Select(x => new EmailAddressDto(x.Name, x.Address)));
                    emailMessage.FromAddresses.AddRange(message.From.Select(x => (MailboxAddress)x).Select(x => new EmailAddressDto(x.Name, x.Address)));

                    emails.Add(emailMessage);
                }

                await emailClient.DisconnectAsync(true);
                return new ApiResponse(Status200OK, null, emails);
            }
        }

        public async Task<ApiResponse> SendEmailAsync(EmailMessageDto emailMessage)
        {
            try
            {
                var message = new MimeMessage();

                // Set From Address it was not set
                if (emailMessage.FromAddresses.Count == 0)
                {
                    emailMessage.FromAddresses.Add(new EmailAddressDto(_emailConfiguration.FromName, _emailConfiguration.FromAddress));
                }

                message.To.AddRange(emailMessage.ToAddresses.Select(x => new MailboxAddress(x.Name, x.Address)));
                message.From.AddRange(emailMessage.FromAddresses.Select(x => new MailboxAddress(x.Name, x.Address)));
                message.Cc.AddRange(emailMessage.CcAddresses.Select(x => new MailboxAddress(x.Name, x.Address)));
                message.Bcc.AddRange(emailMessage.BccAddresses.Select(x => new MailboxAddress(x.Name, x.Address)));

                message.Sender = new MailboxAddress(_emailConfiguration.FromName, _emailConfiguration.FromAddress);

                message.Subject = emailMessage.Subject;

                message.Body = emailMessage.IsHtml ? new BodyBuilder { HtmlBody = emailMessage.Body }.ToMessageBody() : new TextPart("plain") { Text = emailMessage.Body };

                //Be careful that the SmtpClient class is the one from Mailkit not the framework!
                using (var emailClient = new SmtpClient())
                {
                    if (!_emailConfiguration.SmtpUseSSL)
                    {
                        emailClient.ServerCertificateValidationCallback = (object sender2, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) => true;
                    }

                    await emailClient.ConnectAsync(_emailConfiguration.SmtpServer, _emailConfiguration.SmtpPort, _emailConfiguration.SmtpUseSSL);

                    //Remove any OAuth functionality as we won't be using it.
                    emailClient.AuthenticationMechanisms.Remove("XOAUTH2");

                    if (!string.IsNullOrWhiteSpace(_emailConfiguration.SmtpUsername))
                    {
                        await emailClient.AuthenticateAsync(_emailConfiguration.SmtpUsername, _emailConfiguration.SmtpPassword);
                    }

                    await emailClient.SendAsync(message);

                    await emailClient.DisconnectAsync(true);

                    var msg = $"Email successfully sent to {string.Join(" - ", message.To.Select(i => i.Name))}";

                    _logger.LogInformation(msg);

                    return new ApiResponse(Status200OK, msg);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("SendEmailAsync failed ({0}:{1} SSL:{2}): {3} {4}",
                    _emailConfiguration.SmtpServer, _emailConfiguration.SmtpPort, _emailConfiguration.SmtpUseSSL, ex.GetBaseException().Message, ex.StackTrace);

                return new ApiResponse(Status500InternalServerError, ex.GetBaseException().Message);
            }
        }
    }
}
