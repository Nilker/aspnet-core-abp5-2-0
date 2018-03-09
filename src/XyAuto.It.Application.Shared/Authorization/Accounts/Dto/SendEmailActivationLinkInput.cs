using System.ComponentModel.DataAnnotations;

namespace XyAuto.It.Authorization.Accounts.Dto
{
    public class SendEmailActivationLinkInput
    {
        [Required]
        public string EmailAddress { get; set; }
    }
}
