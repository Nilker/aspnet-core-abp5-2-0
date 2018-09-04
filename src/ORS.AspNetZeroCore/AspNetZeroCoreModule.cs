using Abp.Modules;
using Abp.Reflection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ORS.AspNetZeroCore
{
    public class AspNetZeroCoreModule: AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AspNetZeroCoreModule).GetAssembly());
        }
    }
}
