using ORS.AspNetZeroCore.Web.Authentication.External;
using Abp.AutoMapper;

namespace XyAuto.It.Web.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}

