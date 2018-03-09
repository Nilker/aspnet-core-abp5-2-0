using Abp.AutoMapper;
using XyAuto.It.Sessions.Dto;

namespace XyAuto.It.Web.Views.Shared.Components.TenantChange
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}

