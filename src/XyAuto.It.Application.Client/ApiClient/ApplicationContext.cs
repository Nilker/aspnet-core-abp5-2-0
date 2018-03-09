using Abp;
using Abp.Dependency;
using Abp.Localization;
using Abp.Web.Models.AbpUserConfiguration;
using JetBrains.Annotations;
using XyAuto.It.Sessions.Dto;

namespace XyAuto.It.ApiClient
{
    public class ApplicationContext : IApplicationContext, ISingletonDependency
    {
        public TenantInformation CurrentTenant { get; private set; }

        public AbpUserConfigurationDto Configuration { get; set; }

        public GetCurrentLoginInformationsOutput LoginInfo { get; set; }

        public void SetAsTenant([NotNull] string tenancyName, int tenantId)
        {
            Check.NotNull(tenancyName, nameof(tenancyName));

            CurrentTenant = new TenantInformation(tenancyName, tenantId);
        }

        public LanguageInfo CurrentLanguage { get; set; }

        public void SetAsHost()
        {
            CurrentTenant = null;
        }
    }
}
