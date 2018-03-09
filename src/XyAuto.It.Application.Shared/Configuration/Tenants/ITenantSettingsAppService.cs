using System.Threading.Tasks;
using Abp.Application.Services;
using XyAuto.It.Configuration.Tenants.Dto;

namespace XyAuto.It.Configuration.Tenants
{
    public interface ITenantSettingsAppService : IApplicationService
    {
        Task<TenantSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(TenantSettingsEditDto input);

        Task ClearLogo();

        Task ClearCustomCss();
    }
}

