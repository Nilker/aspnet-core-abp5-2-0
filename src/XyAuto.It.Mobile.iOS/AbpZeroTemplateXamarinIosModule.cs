using Abp.Modules;
using Abp.Reflection.Extensions;

namespace XyAuto.It
{
    [DependsOn(typeof(AbpZeroTemplateXamarinSharedModule))]
    public class AbpZeroTemplateXamarinIosModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AbpZeroTemplateXamarinIosModule).GetAssembly());
        }
    }
}
