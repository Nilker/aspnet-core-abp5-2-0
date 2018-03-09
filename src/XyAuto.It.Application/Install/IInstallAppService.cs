using System.Threading.Tasks;
using Abp.Application.Services;
using XyAuto.It.Install.Dto;

namespace XyAuto.It.Install
{
    public interface IInstallAppService : IApplicationService
    {
        Task Setup(InstallDto input);

        AppSettingsJsonDto GetAppSettingsJson();

        CheckDatabaseOutput CheckDatabase();
    }
}
