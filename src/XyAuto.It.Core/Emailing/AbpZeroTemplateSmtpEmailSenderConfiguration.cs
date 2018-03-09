using Abp.Configuration;
using Abp.Net.Mail;
using Abp.Net.Mail.Smtp;
using Abp.Runtime.Security;

namespace XyAuto.It.Emailing
{
    public class AbpZeroTemplateSmtpEmailSenderConfiguration : SmtpEmailSenderConfiguration
    {
        public AbpZeroTemplateSmtpEmailSenderConfiguration(ISettingManager settingManager) : base(settingManager)
        {

        }

        public override string Password => SimpleStringCipher.Instance.Decrypt(GetNotEmptySettingValue(EmailSettingNames.Smtp.Password));
    }
}
