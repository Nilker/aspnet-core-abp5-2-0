using System.Collections.Generic;
using XyAuto.It.Authorization.Permissions.Dto;

namespace XyAuto.It.Authorization.Users.Dto
{
    public class GetUserPermissionsForEditOutput
    {
        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}
