
using System.Linq;
using Abp.Authorization;
using Abp.Localization;
using XyAuto.It.Authorization;

namespace XyAuto.It.Books.Authorization
{
    /// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="BookAppPermissions" /> for all permission names. Book
    ///</summary>
    public class BookAppAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //在这里配置了Book 的权限。
            var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

            var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

            var book = administration.CreateChildPermission(BookAppPermissions.Book, L("Books"));
            book.CreateChildPermission(BookAppPermissions.Book_Create, L("Create"));
            book.CreateChildPermission(BookAppPermissions.Book_Edit, L("Edit"));
            book.CreateChildPermission(BookAppPermissions.Book_Delete, L("Delete"));
            book.CreateChildPermission(BookAppPermissions.Book_BatchDelete, L("BatchDelete"));
            book.CreateChildPermission(BookAppPermissions.Book_ExportToExcel, L("ExportToExcel"));


            //// custom codes

            //// custom codes end
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, AbpZeroTemplateConsts.LocalizationSourceName);
        }
    }
}