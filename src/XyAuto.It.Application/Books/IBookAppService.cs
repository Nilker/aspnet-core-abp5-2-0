

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using XyAuto.It.Books.Dtos;
using XyAuto.It.Test;

namespace XyAuto.It.Books
{
    /// <summary>
    /// Book应用层服务的接口方法
    ///</summary>
    public interface IBookAppService : IApplicationService
    {
        /// <summary>
    /// 获取Book的分页列表信息
    ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<BookListDto>> GetPagedBooks(GetBooksInput input);

		/// <summary>
		/// 通过指定id获取BookListDto信息
		/// </summary>
		Task<BookListDto> GetBookByIdAsync(EntityDto<long> input);


        /// <summary>
        /// 导出Book为excel表
        /// </summary>
        /// <returns></returns>
		//Task<FileDto> GetBooksToExcel();

        /// <summary>
        /// 返回实体的EditDto
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetBookForEditOutput> GetBookForEdit(NullableIdDto<long> input);

        //todo:缺少Dto的生成GetBookForEditOutput


        /// <summary>
        /// 添加或者修改Book的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdateBook(CreateOrUpdateBookInput input);


        /// <summary>
        /// 删除Book信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task DeleteBook(EntityDto<long> input);


        /// <summary>
        /// 批量删除Book
        /// </summary>
        Task BatchDeleteBooksAsync(List<long> input);


		//// custom codes
		 
        //// custom codes end
    }
}
