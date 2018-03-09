using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using XyAuto.It.Authentication.TwoFactor.Google;
using XyAuto.It.Authorization;
using XyAuto.It.Authorization.Roles;
using XyAuto.It.Authorization.Users;
using XyAuto.It.Editions;
using XyAuto.It.MultiTenancy;

namespace XyAuto.It.Identity
{
    public static class IdentityRegistrar
    {
        public static IdentityBuilder Register(IServiceCollection services)
        {
            services.AddLogging();

            return services.AddAbpIdentity<Tenant, User, Role>(options =>
                {
                    options.Tokens.ProviderMap[GoogleAuthenticatorProvider.Name] = new TokenProviderDescriptor(typeof(GoogleAuthenticatorProvider));
                })
                .AddAbpTenantManager<TenantManager>()
                .AddAbpUserManager<UserManager>()
                .AddAbpRoleManager<RoleManager>()
                .AddAbpEditionManager<EditionManager>()
                .AddAbpUserStore<UserStore>()
                .AddAbpRoleStore<RoleStore>()
                .AddAbpUserClaimsPrincipalFactory<UserClaimsPrincipalFactory>()
                .AddAbpSecurityStampValidator<SecurityStampValidator>()
                .AddPermissionChecker<PermissionChecker>()
                .AddAbpSignInManager<SignInManager>()
                .AddDefaultTokenProviders();
        }
    }
}

