using System.ComponentModel.DataAnnotations;

namespace SSDCPortal.Shared.Models.Account
{
    public class ResetPasswordViewModel : ChangePasswordViewModel
    {
        public string Token { get; set; }
    }
}
