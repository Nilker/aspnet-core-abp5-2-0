using System.Collections.Generic;
using Abp.Application.Services.Dto;
using XyAuto.It.Editions.Dto;

namespace XyAuto.It.MultiTenancy.Dto
{
    public class GetTenantFeaturesEditOutput
    {
        public List<NameValueDto> FeatureValues { get; set; }

        public List<FlatFeatureDto> Features { get; set; }
    }
}
