using Abp.AspNetCore;
using Abp.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace ORS.AspNetZeroCore.Web
{
    [DependsOn(typeof(AspNetZeroCoreModule))]
    [DependsOn(typeof(AbpAspNetCoreModule))]
    public class AspNetZeroCoreWebModule : AbpModule
    {
        public override void PreInitialize()
        {
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AspNetZeroCoreWebModule).Assembly);
        }
    }
}
