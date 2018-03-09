namespace XyAuto.It.Configuration.Host.Dto
{
    public class HostUserManagementSettingsEditDto
    {
        public bool IsEmailConfirmationRequiredForLogin { get; set; }

        public bool SmsVerificationEnabled { get; set; }
    }
}
