using System.Collections.Generic;
using Abp.Application.Services.Dto;
using XyAuto.It.Editions.Dto;

namespace XyAuto.It.Web.Areas.AppAreaName.Models.Common
{
    public interface IFeatureEditViewModel
    {
        List<NameValueDto> FeatureValues { get; set; }

        List<FlatFeatureDto> Features { get; set; }
    }
}

