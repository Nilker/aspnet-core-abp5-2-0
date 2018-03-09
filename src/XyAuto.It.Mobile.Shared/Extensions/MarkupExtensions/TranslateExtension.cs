using System;
using XyAuto.It.Core;
using XyAuto.It.Localization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XyAuto.It.Extensions.MarkupExtensions
{
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        public string Text { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (ApplicationBootstrapper.AbpBootstrapper == null || Text == null)
            {
                return Text;
            }

            return L.Localize(Text);
        }
    }
}
