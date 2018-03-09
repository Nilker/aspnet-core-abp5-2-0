using System.Collections.Generic;
using Abp.Localization;
using XyAuto.It.Sessions.Dto;

namespace XyAuto.It.Web.Areas.AppAreaName.Models.Layout
{
    public class HeaderViewModel
    {
        public GetCurrentLoginInformationsOutput LoginInformations { get; set; }

        public IReadOnlyList<LanguageInfo> Languages { get; set; }

        public LanguageInfo CurrentLanguage { get; set; }

        public bool IsMultiTenancyEnabled { get; set; }

        public bool IsImpersonatedLogin { get; set; }

        public bool HasUiCustomizationPagePermission { get; set; }

        public int SubscriptionExpireNootifyDayCount { get; set; }

        public string GetShownLoginName()
        {
            var userName = "<span id=\"HeaderCurrentUserName\">" + LoginInformations.User.UserName + "</span>";

            if (!IsMultiTenancyEnabled)
            {
                return userName;
            }

            return LoginInformations.Tenant == null
                ? "<span class='tenancy-name'>.\\</span>" + userName
                : "<span class='tenancy-name'>" + LoginInformations.Tenant.TenancyName + "\\" + "</span>" + userName;
        }

        public string GetLogoUrl(string appPath, string menuSkin)
        {
            if (!IsMultiTenancyEnabled || LoginInformations.Tenant?.LogoId == null)
            {
                return appPath + $"Common/Images/app-logo-on-{menuSkin}.png";
            }

            //id parameter is used to prevent caching only.
            return appPath + "TenantCustomization/GetLogo?id=" + LoginInformations.Tenant.LogoId;
        }
    }
}

