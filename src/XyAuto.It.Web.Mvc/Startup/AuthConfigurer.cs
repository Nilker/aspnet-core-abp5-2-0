using System;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Abp.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace XyAuto.It.Web.Startup
{
    public static class AuthConfigurer
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            var authenticationBuilder = services.AddAuthentication();

            if (bool.Parse(configuration["Authentication:OpenId:IsEnabled"]))
            {
                authenticationBuilder.AddOpenIdConnect(options =>
                {
                    options.ClientId = configuration["Authentication:OpenId:ClientId"];
                    options.Authority = configuration["Authentication:OpenId:Authority"];
                    options.SignedOutRedirectUri = configuration["App:WebSiteRootAddress"] + "Account/Logout";
                    options.ResponseType = OpenIdConnectResponseType.IdToken;

                    var clientSecret = configuration["Authentication:OpenId:ClientSecret"];
                    if (!clientSecret.IsNullOrEmpty())
                    {
                        options.ClientSecret = clientSecret;
                    }
                });
            }

            if (bool.Parse(configuration["Authentication:Microsoft:IsEnabled"]))
            {
                authenticationBuilder.AddMicrosoftAccount(options =>
                {
                    options.ClientId = configuration["Authentication:Microsoft:ConsumerKey"];
                    options.ClientSecret = configuration["Authentication:Microsoft:ConsumerSecret"];
                });
            }

            if (bool.Parse(configuration["Authentication:Google:IsEnabled"]))
            {
                authenticationBuilder.AddGoogle(options =>
                {
                    options.ClientId = configuration["Authentication:Google:ClientId"];
                    options.ClientSecret = configuration["Authentication:Google:ClientSecret"];
                });
            }

            if (bool.Parse(configuration["Authentication:Twitter:IsEnabled"]))
            {
                authenticationBuilder.AddTwitter(options =>
                {
                    options.ConsumerKey = configuration["Authentication:Twitter:ConsumerKey"];
                    options.ConsumerSecret = configuration["Authentication:Twitter:ConsumerSecret"];
                    options.RetrieveUserDetails = true;
                });
            }

            if (bool.Parse(configuration["Authentication:Facebook:IsEnabled"]))
            {
                authenticationBuilder.AddFacebook(options =>
                {
                    options.AppId = configuration["Authentication:Facebook:AppId"];
                    options.AppSecret = configuration["Authentication:Facebook:AppSecret"];

                    options.Scope.Add("email");
                    options.Scope.Add("public_profile");
                });
            }

            if (bool.Parse(configuration["Authentication:JwtBearer:IsEnabled"]))
            {
                authenticationBuilder.AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        // The signing key must match!
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["Authentication:JwtBearer:SecurityKey"])),

                        // Validate the JWT Issuer (iss) claim
                        ValidateIssuer = true,
                        ValidIssuer = configuration["Authentication:JwtBearer:Issuer"],

                        // Validate the JWT Audience (aud) claim
                        ValidateAudience = true,
                        ValidAudience = configuration["Authentication:JwtBearer:Audience"],

                        // Validate the token expiry
                        ValidateLifetime = true,

                        // If you want to allow a certain amount of clock drift, set that here
                        ClockSkew = TimeSpan.Zero
                    };
                });
            }

            if (bool.Parse(configuration["IdentityServer:IsEnabled"]))
            {
                authenticationBuilder.AddIdentityServerAuthentication("IdentityBearer", options =>
                {
                    options.Authority = configuration["App:WebSiteRootAddress"];
                    options.RequireHttpsMetadata = false;
                });
            }
        }
    }
}

