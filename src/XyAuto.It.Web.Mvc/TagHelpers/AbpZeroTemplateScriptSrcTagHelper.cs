using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace XyAuto.It.Web.TagHelpers
{
    [HtmlTargetElement("script")]
    public class AbpZeroTemplateScriptSrcTagHelper : TagHelper
    {
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);

            if (output.Attributes["abp-ignore-src-modification"] != null && output.Attributes["abp-ignore-src-modification"].Value.ToString() == "true")
            {
                return;
            }

            string srcKey;
            if (output.Attributes["abp-src"] != null)
            {
                srcKey = "abp-src";
            }
            else if (output.Attributes["src"] != null)
            {
                srcKey = "src";
            }
            else
            {
                return;
            }

            if (output.Attributes[srcKey].Value.ToString().StartsWith("~"))
            {
                return;
            }

            if (output.Attributes[srcKey].Value is HtmlString ||
                output.Attributes[srcKey].Value is string)
            {
                var href = output.Attributes[srcKey].Value.ToString();
                if (href.StartsWith("~"))
                {
                    return;
                }

                var basePath = ViewContext.HttpContext.Request.PathBase.HasValue
                    ? ViewContext.HttpContext.Request.PathBase.Value
                    : string.Empty;

                output.Attributes.SetAttribute("src", basePath + href);
            }
        }
    }
}
