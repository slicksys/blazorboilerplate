using System.ComponentModel.DataAnnotations;

namespace SSDCPortal.Shared.Models.Account
{
    public class ForgotPasswordViewModel
    {
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
