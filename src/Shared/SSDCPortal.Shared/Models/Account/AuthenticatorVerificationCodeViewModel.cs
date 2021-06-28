using System.ComponentModel.DataAnnotations;

namespace SSDCPortal.Shared.Models.Account
{
    public class AuthenticatorVerificationCodeViewModel
    {
        [DataType(DataType.Text)]
        [Display(Name = "VerificationCode")]
        public string Code { get; set; }
    }
}
