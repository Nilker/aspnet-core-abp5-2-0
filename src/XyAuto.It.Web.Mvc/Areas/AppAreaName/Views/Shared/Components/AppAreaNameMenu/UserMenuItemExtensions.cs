using Abp.Application.Navigation;
using ORS.AspNetZeroCore.Web.Url;

namespace XyAuto.It.Web.Areas.AppAreaName.Views.Shared.Components.AppAreaNameSideBar
{
    public static class UserMenuItemExtensions
    {
        public static bool IsMenuActive(this UserMenuItem menuItem, string currentPageName)
        {
            if (menuItem.Name == currentPageName)
            {
                return true;
            }

            if (menuItem.Items != null)
            {
                foreach (var subMenuItem in menuItem.Items)
                {
                    if (subMenuItem.IsMenuActive(currentPageName))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static string CalculateUrl(this UserMenuItem menuItem, string applicationPath)
        {
            if (string.IsNullOrEmpty(menuItem.Url))
            {
                return applicationPath;
            }

            if (UrlChecker.IsRooted(menuItem.Url))
            {
                return menuItem.Url;
            }

            return applicationPath + menuItem.Url;
        }
    }
}

