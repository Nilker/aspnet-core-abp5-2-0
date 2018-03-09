using System;
using XyAuto.It.Core;
using XyAuto.It.Core.Dependency;
using XyAuto.It.Services.Permission;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XyAuto.It.Extensions.MarkupExtensions
{
    [ContentProperty("Text")]
    public class HasPermissionExtension : IMarkupExtension
    {
        public string Text { get; set; }
        
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (ApplicationBootstrapper.AbpBootstrapper == null || Text == null)
            {
                return false;
            }

            var permissionService = DependencyResolver.Resolve<IPermissionService>();
            return permissionService.HasPermission(Text);
        }
    }
}
