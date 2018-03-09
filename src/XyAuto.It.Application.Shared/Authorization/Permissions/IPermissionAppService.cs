using Abp.Application.Services;
using Abp.Application.Services.Dto;
using XyAuto.It.Authorization.Permissions.Dto;

namespace XyAuto.It.Authorization.Permissions
{
    public interface IPermissionAppService : IApplicationService
    {
        ListResultDto<FlatPermissionWithLevelDto> GetAllPermissions();
    }
}

