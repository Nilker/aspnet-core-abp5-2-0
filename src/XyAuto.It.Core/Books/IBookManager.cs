

using System;
using System.Threading.Tasks;
using Abp;
using Abp.Domain.Services;
using XyAuto.It.Test;


namespace XyAuto.It.Books
{
    public interface IBookManager : IDomainService
    {

        /// <summary>
    /// 初始化方法
    ///</summary>
        void InitBook();



		//// custom codes
 
        //// custom codes end

    }
}
