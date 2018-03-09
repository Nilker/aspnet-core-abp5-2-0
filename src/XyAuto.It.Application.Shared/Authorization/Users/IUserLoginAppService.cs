using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using XyAuto.It.Authorization.Users.Dto;

namespace XyAuto.It.Authorization.Users
{
    public interface IUserLoginAppService : IApplicationService
    {
        Task<ListResultDto<UserLoginAttemptDto>> GetRecentUserLoginAttempts();
    }
}

