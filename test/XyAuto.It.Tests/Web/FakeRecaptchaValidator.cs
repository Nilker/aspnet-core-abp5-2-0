using System.Threading.Tasks;
using XyAuto.It.Security.Recaptcha;

namespace XyAuto.It.Tests.Web
{
    public class FakeRecaptchaValidator : IRecaptchaValidator
    {
        public Task ValidateAsync(string captchaResponse)
        {
            return Task.CompletedTask;
        }
    }
}

