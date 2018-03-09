using Abp.Authorization;
using XyAuto.It.Authorization.Roles;
using XyAuto.It.Authorization.Users;

namespace XyAuto.It.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}

