using System.Threading.Tasks;

namespace XyAuto.It.Security.Recaptcha
{
    public interface IRecaptchaValidator
    {
        Task ValidateAsync(string captchaResponse);
    }
}
