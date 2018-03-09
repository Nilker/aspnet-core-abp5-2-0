using Abp.AutoMapper;
using XyAuto.It.Authorization.Users;
using XyAuto.It.Authorization.Users.Dto;
using XyAuto.It.Web.Areas.AppAreaName.Models.Common;

namespace XyAuto.It.Web.Areas.AppAreaName.Models.Users
{
    [AutoMapFrom(typeof(GetUserPermissionsForEditOutput))]
    public class UserPermissionsEditViewModel : GetUserPermissionsForEditOutput, IPermissionsEditViewModel
    {
        public User User { get; private set; }

        public UserPermissionsEditViewModel(GetUserPermissionsForEditOutput output, User user)
        {
            User = user;
            output.MapTo(this);
        }
    }
}

