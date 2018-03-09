using Abp.Modules;
using Abp.Reflection.Extensions;

namespace XyAuto.It
{
    [DependsOn(typeof(AbpZeroTemplateXamarinSharedModule))]
    public class AbpZeroTemplateXamarinAndroidModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AbpZeroTemplateXamarinAndroidModule).GetAssembly());
        }
    }
}
