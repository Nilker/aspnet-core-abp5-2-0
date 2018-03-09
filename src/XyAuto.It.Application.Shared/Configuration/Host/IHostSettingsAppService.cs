using System.Threading.Tasks;
using Abp.Application.Services;
using XyAuto.It.Configuration.Host.Dto;

namespace XyAuto.It.Configuration.Host
{
    public interface IHostSettingsAppService : IApplicationService
    {
        Task<HostSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(HostSettingsEditDto input);

        Task SendTestEmail(SendTestEmailInput input);
    }
}

