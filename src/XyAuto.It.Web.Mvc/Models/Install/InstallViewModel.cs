using System.Collections.Generic;
using Abp.Localization;
using XyAuto.It.Install.Dto;

namespace XyAuto.It.Web.Models.Install
{
    public class InstallViewModel
    {
        public List<ApplicationLanguage> Languages { get; set; }

        public AppSettingsJsonDto AppSettingsJson { get; set; }
    }
}


