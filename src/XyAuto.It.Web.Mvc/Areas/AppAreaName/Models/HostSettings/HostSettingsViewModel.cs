using System.Collections.Generic;
using Abp.Application.Services.Dto;
using XyAuto.It.Configuration.Host.Dto;
using XyAuto.It.Editions.Dto;

namespace XyAuto.It.Web.Areas.AppAreaName.Models.HostSettings
{
    public class HostSettingsViewModel
    {
        public HostSettingsEditDto Settings { get; set; }

        public List<SubscribableEditionComboboxItemDto> EditionItems { get; set; }

        public List<ComboboxItemDto> TimezoneItems { get; set; }
    }
}

