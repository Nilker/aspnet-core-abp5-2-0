using System.Collections.Generic;
using MvvmHelpers;
using XyAuto.It.Models.NavigationMenu;

namespace XyAuto.It.Services.Navigation
{
    public interface IMenuProvider
    {
        ObservableRangeCollection<NavigationMenuItem> GetAuthorizedMenuItems(Dictionary<string, string> grantedPermissions);
    }
}
