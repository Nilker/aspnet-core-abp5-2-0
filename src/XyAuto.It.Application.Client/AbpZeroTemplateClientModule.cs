using Abp.Modules;
using Abp.Reflection.Extensions;

namespace XyAuto.It
{
    public class AbpZeroTemplateClientModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AbpZeroTemplateClientModule).GetAssembly());
        }
    }
}

