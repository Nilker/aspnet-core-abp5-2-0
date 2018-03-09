using System.ComponentModel.DataAnnotations;

namespace XyAuto.It.Web.Models.Account
{
    public class SendPasswordResetLinkViewModel
    {
        [Required]
        public string EmailAddress { get; set; }
    }
}
