using Abp.AutoMapper;
using XyAuto.It.MultiTenancy;
using XyAuto.It.MultiTenancy.Dto;
using XyAuto.It.Web.Areas.AppAreaName.Models.Common;

namespace XyAuto.It.Web.Areas.AppAreaName.Models.Tenants
{
    [AutoMapFrom(typeof (GetTenantFeaturesEditOutput))]
    public class TenantFeaturesEditViewModel : GetTenantFeaturesEditOutput, IFeatureEditViewModel
    {
        public Tenant Tenant { get; set; }

        public TenantFeaturesEditViewModel(Tenant tenant, GetTenantFeaturesEditOutput output)
        {
            Tenant = tenant;
            output.MapTo(this);
        }
    }
}

