using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using SSDCPortal.Shared.Dto.Sample;
using SSDCPortal.Shared.Interfaces;
using SSDCPortal.Shared.Models.Account;
using SSDCPortal.Shared.Providers;
using SSDCPortal.Theme.Material.HR.Hubs;

namespace SSDCPortal.Theme.Material.HR.Pages.Forum
{
    public class ForumPageModel : ComponentBase, IDisposable
    {
        [Inject]
        private AuthenticationStateProvider authStateProvider { get; set; }

        [Inject]
        private HttpClient httpClient { get; set; }

        [CascadingParameter]
        private Task<AuthenticationState> AuthenticationStateTask { get; set; }

        [Inject]
        private IViewNotifier viewNotifier { get; set; }

        UserViewModel userViewModel { get; set; } = new UserViewModel();

        ChatClient Client { get; set; }

        public string MessagePost { get; set; }

        public List<MessageDto> Messages = new List<MessageDto>();

        protected override async Task OnInitializedAsync()
        {
            userViewModel = await ((IdentityAuthenticationStateProvider)authStateProvider).GetUserViewModel();

            await AuthenticationStateTask;
            await Chat();
        }

        async Task Chat()
        {
            try
            {
                Messages.Clear();

                Client = new ChatClient(httpClient);

                Client.MessageReceived += MessageReceived;

                await Client.Start();

                viewNotifier.Show("Chat started", ViewNotifierType.Info);
            }
            catch (Exception e)
            {
                viewNotifier.Show($"ERROR: Failed to start chat client: {e.Message}", ViewNotifierType.Error);
            }
        }

        void MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            bool isMine = false;
            if (!string.IsNullOrWhiteSpace(e.Username))
            {
                isMine = string.Equals(e.Username, userViewModel.UserName, StringComparison.CurrentCultureIgnoreCase);
            }

            var newMessage = new MessageDto(e.Id, e.Username, e.Message, isMine);
            Messages.Insert(0, newMessage);

            StateHasChanged();
        }

        async Task Disconnect()
        {
            await Client.Stop();
            Client.Dispose();
            Client = null;

            viewNotifier.Show("Chat ended", ViewNotifierType.Info);
        }

        public async Task Delete(MessageDto messageDto)
        {
            if (messageDto != null)
            {
                await Client.Delete(messageDto.Id);

                Messages.Remove(messageDto);

                StateHasChanged();
            }
        }

        public async Task Send(MessageDto messageDto)
        {
            if (!string.IsNullOrWhiteSpace(messageDto.Text))
            {
                await Client.Send(messageDto.Text);

                StateHasChanged();
            }
        }

        protected override void Dispose()
        {
            _ = Disconnect();
        }
    }
}
