using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace XyAuto.It.Web.Public.Startup
{
    public static class AuthConfigurer
    {
        /// <summary>
        /// Configures the specified application.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="configuration">The configuration.</param>
        public static void Configure(IApplicationBuilder app, IConfiguration configuration)
        {
            app.UseIdentity();
        }
    }
}

