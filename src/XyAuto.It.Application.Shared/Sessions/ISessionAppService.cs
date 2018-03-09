using System.Threading.Tasks;
using Abp.Application.Services;
using XyAuto.It.Sessions.Dto;

namespace XyAuto.It.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();

        Task<UpdateUserSignInTokenOutput> UpdateUserSignInToken();
    }
}

