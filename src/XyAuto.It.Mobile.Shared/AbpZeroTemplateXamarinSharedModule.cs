using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace XyAuto.It
{
    [DependsOn(typeof(AbpZeroTemplateClientModule), typeof(AbpAutoMapperModule))]
    public class AbpZeroTemplateXamarinSharedModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Localization.IsEnabled = false;
            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AbpZeroTemplateXamarinSharedModule).GetAssembly());
        }
    }
}
