
namespace XyAuto.It.Courseses.Authorization
{

	 /// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="CoursesAppAuthorizationProvider" />中对权限的定义.
    ///</summary>
	public static  class CoursesAppPermissions
    {
    /// <summary>
        /// Courses管理权限_自带查询授权
        ///</summary>
    public const string Courses = "Pages.Courses";

    /// <summary>
        /// Courses创建权限
        ///</summary>
    public const string Courses_Create = "Pages.Courses.Create";

    /// <summary>
        /// Courses修改权限
        ///</summary>
    public const string Courses_Edit = "Pages.Courses.Edit";

    /// <summary>
        /// Courses删除权限
        ///</summary>
    public const string Courses_Delete = "Pages.Courses.Delete";

    /// <summary>
        /// Courses批量删除权限
        ///</summary>
    public const string Courses_BatchDelete  = "Pages.Courses.BatchDelete";

	  /// <summary>
        /// 导出为Excel表
        ///</summary>
    public const string Courses_ExportToExcel = "Pages.Courses.ExportToExcel";


    //// custom codes
    
    //// custom codes end
    }

}

