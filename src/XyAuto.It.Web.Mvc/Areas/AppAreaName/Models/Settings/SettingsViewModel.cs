using System.Collections.Generic;
using Abp.Application.Services.Dto;
using XyAuto.It.Configuration.Tenants.Dto;

namespace XyAuto.It.Web.Areas.AppAreaName.Models.Settings
{
    public class SettingsViewModel
    {
        public TenantSettingsEditDto Settings { get; set; }
        
        public List<ComboboxItemDto> TimezoneItems { get; set; }
    }
}

