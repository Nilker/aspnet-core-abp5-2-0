using System.Collections.Generic;
using System.Collections.Immutable;
using Abp.Collections.Extensions;
using Abp.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Razor;

namespace XyAuto.It.Web.Resources
{
    public class WebResourceManager : IWebResourceManager
    {
        private readonly IHostingEnvironment _environment;
        private readonly List<string> _scriptUrls;

        public WebResourceManager(IHostingEnvironment environment)
        {
            _environment = environment;
            _scriptUrls = new List<string>();
        }

        public void AddScript(string url, bool addMinifiedOnProd = true)
        {
            _scriptUrls.AddIfNotContains(NormalizeUrl(url, "js"));
        }

        public IReadOnlyList<string> GetScripts()
        {
            return _scriptUrls.ToImmutableList();
        }

        public HelperResult RenderScripts()
        {
            return new HelperResult(async writer =>
            {
                foreach (var scriptUrl in _scriptUrls)
                {
                    await writer.WriteAsync($"<script src=\"{scriptUrl}\" asp-append-version=\"true\"></script>");
                }
            });
        }

        private string NormalizeUrl(string url, string ext)
        {
            if (_environment.IsDevelopment())
            {
                return url;
            }

            if (url.EndsWith(".min." + ext))
            {
                return url;
            }

            return url.Left(url.Length - ext.Length) + "min." + ext;
        }
    }
}

