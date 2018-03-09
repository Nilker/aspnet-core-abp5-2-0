using Abp.AutoMapper;
using XyAuto.It.MultiTenancy.Dto;

namespace XyAuto.It.Web.Models.TenantRegistration
{
    [AutoMapFrom(typeof(RegisterTenantOutput))]
    public class TenantRegisterResultViewModel : RegisterTenantOutput
    {
        public string TenantLoginAddress { get; set; }
    }
}

