
namespace XyAuto.It.Books.Authorization
{

	 /// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="BookAppAuthorizationProvider" />中对权限的定义.
    ///</summary>
	public static  class BookAppPermissions
    {
    /// <summary>
        /// Book管理权限_自带查询授权
        ///</summary>
    public const string Book = "Pages.Book";

    /// <summary>
        /// Book创建权限
        ///</summary>
    public const string Book_Create = "Pages.Book.Create";

    /// <summary>
        /// Book修改权限
        ///</summary>
    public const string Book_Edit = "Pages.Book.Edit";

    /// <summary>
        /// Book删除权限
        ///</summary>
    public const string Book_Delete = "Pages.Book.Delete";

    /// <summary>
        /// Book批量删除权限
        ///</summary>
    public const string Book_BatchDelete  = "Pages.Book.BatchDelete";

	  /// <summary>
        /// 导出为Excel表
        ///</summary>
    public const string Book_ExportToExcel = "Pages.Book.ExportToExcel";


    //// custom codes
    
    //// custom codes end
    }

}

