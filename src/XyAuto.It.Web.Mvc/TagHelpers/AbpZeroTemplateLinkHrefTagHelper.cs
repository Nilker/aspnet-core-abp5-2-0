using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace XyAuto.It.Web.TagHelpers
{
    [HtmlTargetElement("link")]
    public class AbpZeroTemplateLinkHrefTagHelper : TagHelper
    {
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);

            if (output.Attributes["abp-ignore-href-modification"] != null && output.Attributes["abp-ignore-href-modification"].Value.ToString() == "true")
            {
                return;
            }

            string hrefKey;
            if (output.Attributes["abp-href"] != null)
            {
                hrefKey = "abp-href";
            }
            else if (output.Attributes["href"] != null)
            {
                hrefKey = "href";
            }
            else
            {
                return;
            }

            if (output.Attributes[hrefKey].Value is HtmlString ||
                output.Attributes[hrefKey].Value is string)
            {
                var href = output.Attributes[hrefKey].Value.ToString();
                if (href.StartsWith("~"))
                {
                    return;
                }

                var basePath = ViewContext.HttpContext.Request.PathBase.HasValue
                    ? ViewContext.HttpContext.Request.PathBase.Value
                    : string.Empty;

                output.Attributes.SetAttribute("href", basePath + href);
            }
        }
    }
}
