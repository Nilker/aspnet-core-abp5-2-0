using System.Collections.Generic;
using XyAuto.It.Authorization.Permissions.Dto;

namespace XyAuto.It.Web.Areas.AppAreaName.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }

        List<string> GrantedPermissionNames { get; set; }
    }
}

