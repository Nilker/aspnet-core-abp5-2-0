using Microsoft.Extensions.Configuration;

namespace XyAuto.It.Configuration
{
    public interface IAppConfigurationAccessor
    {
        IConfigurationRoot Configuration { get; }
    }
}

