

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using XyAuto.It.Courseses.Dtos;
using XyAuto.It.Test;

namespace XyAuto.It.Courseses
{
    /// <summary>
    /// Courses应用层服务的接口方法
    ///</summary>
    public interface ICoursesAppService : IApplicationService
    {
        /// <summary>
    /// 获取Courses的分页列表信息
    ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<CoursesListDto>> GetPagedCoursess(GetCoursessInput input);

		/// <summary>
		/// 通过指定id获取CoursesListDto信息
		/// </summary>
		Task<CoursesListDto> GetCoursesByIdAsync(EntityDto<int> input);


        /// <summary>
        /// 导出Courses为excel表
        /// </summary>
        /// <returns></returns>
		//Task<FileDto> GetCoursessToExcel();

        /// <summary>
        /// 返回实体的EditDto
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetCoursesForEditOutput> GetCoursesForEdit(NullableIdDto<int> input);

        //todo:缺少Dto的生成GetCoursesForEditOutput


        /// <summary>
        /// 添加或者修改Courses的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdateCourses(CreateOrUpdateCoursesInput input);


        /// <summary>
        /// 删除Courses信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task DeleteCourses(EntityDto<int> input);


        /// <summary>
        /// 批量删除Courses
        /// </summary>
        Task BatchDeleteCoursessAsync(List<int> input);


		//// custom codes
		 
        //// custom codes end
    }
}
