using System.Collections.Generic;

namespace ORS.AspNetZeroCore.Web.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
