using System.Collections.Generic;
using XyAuto.It.Caching.Dto;

namespace XyAuto.It.Web.Areas.AppAreaName.Models.Maintenance
{
    public class MaintenanceViewModel
    {
        public IReadOnlyList<CacheDto> Caches { get; set; }
    }
}

