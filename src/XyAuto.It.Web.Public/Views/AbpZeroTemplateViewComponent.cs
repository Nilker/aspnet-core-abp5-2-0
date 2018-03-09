using Abp.AspNetCore.Mvc.ViewComponents;

namespace XyAuto.It.Web.Public.Views
{
    public abstract class AbpZeroTemplateViewComponent : AbpViewComponent
    {
        protected AbpZeroTemplateViewComponent()
        {
            LocalizationSourceName = AbpZeroTemplateConsts.LocalizationSourceName;
        }
    }
}
