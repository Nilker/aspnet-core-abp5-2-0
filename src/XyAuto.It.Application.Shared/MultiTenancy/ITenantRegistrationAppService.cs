using System.Threading.Tasks;
using Abp.Application.Services;
using XyAuto.It.Editions.Dto;
using XyAuto.It.MultiTenancy.Dto;

namespace XyAuto.It.MultiTenancy
{
    public interface ITenantRegistrationAppService: IApplicationService
    {
        Task<RegisterTenantOutput> RegisterTenant(RegisterTenantInput input);

        Task<EditionsSelectOutput> GetEditionsForSelect();

        Task<EditionSelectDto> GetEdition(int editionId);
    }
}
