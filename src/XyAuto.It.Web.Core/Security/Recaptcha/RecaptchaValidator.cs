using System;
using System.Threading.Tasks;
using Abp.Dependency;
using Abp.Extensions;
using Abp.UI;
using Microsoft.AspNetCore.Http;
using XyAuto.It.Security.Recaptcha;
using PaulMiami.AspNetCore.Mvc.Recaptcha;

namespace XyAuto.It.Web.Security.Recaptcha
{
    public class RecaptchaValidator : AbpZeroTemplateServiceBase, IRecaptchaValidator, ITransientDependency
    {
        public const string RecaptchaResponseKey = "g-recaptcha-response";

        private readonly IRecaptchaValidationService _recaptchaValidationService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RecaptchaValidator(IRecaptchaValidationService recaptchaValidationService, IHttpContextAccessor httpContextAccessor)
        {
            _recaptchaValidationService = recaptchaValidationService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task ValidateAsync(string captchaResponse)
        {
            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext == null)
            {
                throw new Exception("RecaptchaValidator should be used in a valid HTTP context!");
            }

            if (captchaResponse.IsNullOrEmpty())
            {
                throw new UserFriendlyException(L("CaptchaCanNotBeEmpty"));
            }

            try
            {
                await _recaptchaValidationService.ValidateResponseAsync(
                    captchaResponse,
                    _httpContextAccessor.HttpContext.Connection?.RemoteIpAddress?.ToString()
                );
            }
            catch (RecaptchaValidationException)
            {
                throw new UserFriendlyException(L("IncorrectCaptchaAnswer"));
            }
        }
    }
}


