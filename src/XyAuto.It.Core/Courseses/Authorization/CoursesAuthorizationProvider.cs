
using System.Linq;
using Abp.Authorization;
using Abp.Localization;
using XyAuto.It.Authorization;

namespace XyAuto.It.Courseses.Authorization
{
    /// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="CoursesAppPermissions" /> for all permission names. Courses
    ///</summary>
    public class CoursesAppAuthorizationProvider : AuthorizationProvider
    {
    public override void SetPermissions(IPermissionDefinitionContext context)
    {
    //在这里配置了Courses 的权限。
    var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

    var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

    var courses = administration.CreateChildPermission(CoursesAppPermissions.Courses , L("Courseses"));
courses.CreateChildPermission(CoursesAppPermissions.Courses_Create, L("Create"));
courses.CreateChildPermission(CoursesAppPermissions.Courses_Edit, L("Edit"));
courses.CreateChildPermission(CoursesAppPermissions.Courses_Delete, L("Delete"));
courses.CreateChildPermission(CoursesAppPermissions.Courses_BatchDelete , L("BatchDelete"));
courses.CreateChildPermission(CoursesAppPermissions.Courses_ExportToExcel, L("ExportToExcel"));


    //// custom codes
    
    //// custom codes end
    }

    private static ILocalizableString L(string name)
    {
    return new LocalizableString(name, AbpZeroTemplateConsts.LocalizationSourceName);
    }
    }
    }