using System.ComponentModel.DataAnnotations;

namespace SSDCPortal.Shared.Models.Account
{
    public class LoginWithRecoveryCodeInputModel : LoginWith2faModel
    {
        [DataType(DataType.Text)]
        public string RecoveryCode { get; set; }
    }
}
