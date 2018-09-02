
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;

using System.Linq.Dynamic.Core;
 using Microsoft.EntityFrameworkCore; 

using XyAuto.It.Courseses.Authorization;
using XyAuto.It.Courseses.Dtos;
using XyAuto.It.Test;
using AutoMapper;

namespace XyAuto.It.Courseses
{
    /// <summary>
    /// Courses应用层服务的接口实现方法  
    ///</summary>
[AbpAuthorize(CoursesAppPermissions.Courses)] 
    public class CoursesAppService : AbpZeroTemplateAppServiceBase, ICoursesAppService
    {
    private readonly IRepository<Courses, int>
    _coursesRepository;
    
       
       private readonly ICoursesManager _coursesManager;

    /// <summary>
        /// 构造函数 
        ///</summary>
    public CoursesAppService(
    IRepository<Courses, int>
coursesRepository
        ,ICoursesManager coursesManager
        )
        {
        _coursesRepository = coursesRepository;
  _coursesManager=coursesManager;
        }


        /// <summary>
            /// 获取Courses的分页列表信息
            ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public  async  Task<PagedResultDto<CoursesListDto>> GetPagedCoursess(GetCoursessInput input)
		{

		    var query = _coursesRepository.GetAll();
			// TODO:根据传入的参数添加过滤条件

			var coursesCount = await query.CountAsync();

			var coursess = await query
					.OrderBy(input.Sorting).AsNoTracking()
					.PageBy(input)
					.ToListAsync();

				// var coursesListDtos = ObjectMapper.Map<List <CoursesListDto>>(coursess);
				var coursesListDtos =coursess.MapTo<List<CoursesListDto>>();

				return new PagedResultDto<CoursesListDto>(
coursesCount,
coursesListDtos
					);
		}


		/// <summary>
		/// 通过指定id获取CoursesListDto信息
		/// </summary>
		public async Task<CoursesListDto> GetCoursesByIdAsync(EntityDto<int> input)
		{
			var entity = await _coursesRepository.GetAsync(input.Id);

		    return entity.MapTo<CoursesListDto>();
		}

		/// <summary>
		/// MPA版本才会用到的方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public async  Task<GetCoursesForEditOutput> GetCoursesForEdit(NullableIdDto<int> input)
		{
			var output = new GetCoursesForEditOutput();
CoursesEditDto coursesEditDto;

			if (input.Id.HasValue)
			{
				var entity = await _coursesRepository.GetAsync(input.Id.Value);

coursesEditDto = entity.MapTo<CoursesEditDto>();

				//coursesEditDto = ObjectMapper.Map<List <coursesEditDto>>(entity);
			}
			else
			{
coursesEditDto = new CoursesEditDto();
			}

			output.Courses = coursesEditDto;
			return output;
		}


		/// <summary>
		/// 添加或者修改Courses的公共方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public async Task CreateOrUpdateCourses(CreateOrUpdateCoursesInput input)
		{

			if (input.Courses.Id.HasValue)
			{
				await UpdateCoursesAsync(input.Courses);
			}
			else
			{
				await CreateCoursesAsync(input.Courses);
			}
		}


		/// <summary>
		/// 新增Courses
		/// </summary>
		[AbpAuthorize(CoursesAppPermissions.Courses_Create)]
		protected virtual async Task<CoursesEditDto> CreateCoursesAsync(CoursesEditDto input)
		{
			//TODO:新增前的逻辑判断，是否允许新增

			var entity = ObjectMapper.Map <Courses>(input);

			entity = await _coursesRepository.InsertAsync(entity);
			return entity.MapTo<CoursesEditDto>();
		}

		/// <summary>
		/// 编辑Courses
		/// </summary>
		[AbpAuthorize(CoursesAppPermissions.Courses_Edit)]
		protected virtual async Task UpdateCoursesAsync(CoursesEditDto input)
		{
			//TODO:更新前的逻辑判断，是否允许更新

			var entity = await _coursesRepository.GetAsync(input.Id.Value);
			input.MapTo(entity);

			// ObjectMapper.Map(input, entity);
		    await _coursesRepository.UpdateAsync(entity);
		}



		/// <summary>
		/// 删除Courses信息的方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAuthorize(CoursesAppPermissions.Courses_Delete)]
		public async Task DeleteCourses(EntityDto<int> input)
		{
			//TODO:删除前的逻辑判断，是否允许删除
			await _coursesRepository.DeleteAsync(input.Id);
		}



		/// <summary>
		/// 批量删除Courses的方法
		/// </summary>
		          [AbpAuthorize(CoursesAppPermissions.Courses_BatchDelete)]
		public async Task BatchDeleteCoursessAsync(List<int> input)
		{
			//TODO:批量删除前的逻辑判断，是否允许删除
			await _coursesRepository.DeleteAsync(s => input.Contains(s.Id));
		}


		/// <summary>
		/// 导出Courses为excel表,等待开发。
		/// </summary>
		/// <returns></returns>
		//public async Task<FileDto> GetCoursessToExcel()
		//{
		//	var users = await UserManager.Users.ToListAsync();
		//	var userListDtos = ObjectMapper.Map<List<UserListDto>>(users);
		//	await FillRoleNames(userListDtos);
		//	return _userListExcelExporter.ExportToFile(userListDtos);
		//}



		//// custom codes
		 
        //// custom codes end

    }
}


