

using System;
using System.Threading.Tasks;
using Abp;
using Abp.Domain.Services;
using XyAuto.It.Test;


namespace XyAuto.It.Courseses
{
    public interface ICoursesManager : IDomainService
    {

        /// <summary>
    /// 初始化方法
    ///</summary>
        void InitCourses();



		//// custom codes
 
        //// custom codes end

    }
}
