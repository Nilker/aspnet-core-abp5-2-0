using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using XyAuto.It.Authorization;
using XyAuto.It.Books.Authorization;
using XyAuto.It.Books.Dtos.CustomMapper;
using XyAuto.It.Courseses.Authorization;
using XyAuto.It.Courseses.Dtos.CustomMapper;

namespace XyAuto.It
{
    /// <summary>
    /// Application layer module of the application.
    /// </summary>
    [DependsOn(
        typeof(AbpZeroTemplateCoreModule)
        )]
    public class AbpZeroTemplateApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Adding authorization providers
            Configuration.Authorization.Providers.Add<AppAuthorizationProvider>();

            Configuration.Authorization.Providers.Add<BookAppAuthorizationProvider>();

            Configuration.Authorization.Providers.Add<CoursesAppAuthorizationProvider>();

            //Adding custom AutoMapper configuration
            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                configuration => 
                {
                    CustomDtoMapper.CreateMappings(configuration);
                    CustomerBookMapper.CreateMappings(configuration);
                    CustomerCoursesMapper.CreateMappings(configuration);
                });
                //CustomDtoMapper.CreateMappings);

        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AbpZeroTemplateApplicationModule).GetAssembly());
        }
    }
}
