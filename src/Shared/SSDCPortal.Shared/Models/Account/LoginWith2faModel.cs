using System.ComponentModel.DataAnnotations;

namespace SSDCPortal.Shared.Models.Account
{
    public class LoginWith2faModel : AccountFormModel
    {
        [Display(Name = "RememberBrowser")]
        public bool RememberMachine { get; set; }
    }
}
