using Abp.Application.Services;
using XyAuto.It.Dto;
using XyAuto.It.Logging.Dto;

namespace XyAuto.It.Logging
{
    public interface IWebLogAppService : IApplicationService
    {
        GetLatestWebLogsOutput GetLatestWebLogs();

        FileDto DownloadWebLogs();
    }
}

