
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

using XyAuto.It.Books.Authorization;
using XyAuto.It.Books.Dtos;
using XyAuto.It.Test;

namespace XyAuto.It.Books
{
    /// <summary>
    /// Book应用层服务的接口实现方法  
    ///</summary>
[AbpAuthorize(BookAppPermissions.Book)] 
    public class BookAppService : AbpZeroTemplateAppServiceBase, IBookAppService
    {
    private readonly IRepository<Book, long>
    _bookRepository;
    
       
       private readonly IBookManager _bookManager;

    /// <summary>
        /// 构造函数 
        ///</summary>
    public BookAppService(
    IRepository<Book, long>
bookRepository
        ,IBookManager bookManager
        )
        {
        _bookRepository = bookRepository;
  _bookManager=bookManager;
        }


        /// <summary>
            /// 获取Book的分页列表信息
            ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public  async  Task<PagedResultDto<BookListDto>> GetPagedBooks(GetBooksInput input)
		{

		    var query = _bookRepository.GetAll();
			// TODO:根据传入的参数添加过滤条件

			var bookCount = await query.CountAsync();

			var books = await query
					.OrderBy(input.Sorting).AsNoTracking()
					.PageBy(input)
					.ToListAsync();

				// var bookListDtos = ObjectMapper.Map<List <BookListDto>>(books);
				var bookListDtos =books.MapTo<List<BookListDto>>();

				return new PagedResultDto<BookListDto>(
bookCount,
bookListDtos
					);
		}


		/// <summary>
		/// 通过指定id获取BookListDto信息
		/// </summary>
		public async Task<BookListDto> GetBookByIdAsync(EntityDto<long> input)
		{
			var entity = await _bookRepository.GetAsync(input.Id);

		    return entity.MapTo<BookListDto>();
		}

		/// <summary>
		/// MPA版本才会用到的方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public async  Task<GetBookForEditOutput> GetBookForEdit(NullableIdDto<long> input)
		{
			var output = new GetBookForEditOutput();
BookEditDto bookEditDto;

			if (input.Id.HasValue)
			{
				var entity = await _bookRepository.GetAsync(input.Id.Value);

bookEditDto = entity.MapTo<BookEditDto>();

				//bookEditDto = ObjectMapper.Map<List <bookEditDto>>(entity);
			}
			else
			{
bookEditDto = new BookEditDto();
			}

			output.Book = bookEditDto;
			return output;
		}


		/// <summary>
		/// 添加或者修改Book的公共方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public async Task CreateOrUpdateBook(CreateOrUpdateBookInput input)
		{

			if (input.Book.Id.HasValue)
			{
				await UpdateBookAsync(input.Book);
			}
			else
			{
				await CreateBookAsync(input.Book);
			}
		}


		/// <summary>
		/// 新增Book
		/// </summary>
		[AbpAuthorize(BookAppPermissions.Book_Create)]
		protected virtual async Task<BookEditDto> CreateBookAsync(BookEditDto input)
		{
			//TODO:新增前的逻辑判断，是否允许新增

			var entity = ObjectMapper.Map <Book>(input);

			entity = await _bookRepository.InsertAsync(entity);
			return entity.MapTo<BookEditDto>();
		}

		/// <summary>
		/// 编辑Book
		/// </summary>
		[AbpAuthorize(BookAppPermissions.Book_Edit)]
		protected virtual async Task UpdateBookAsync(BookEditDto input)
		{
			//TODO:更新前的逻辑判断，是否允许更新

			var entity = await _bookRepository.GetAsync(input.Id.Value);
			input.MapTo(entity);

			// ObjectMapper.Map(input, entity);
		    await _bookRepository.UpdateAsync(entity);
		}



		/// <summary>
		/// 删除Book信息的方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAuthorize(BookAppPermissions.Book_Delete)]
		public async Task DeleteBook(EntityDto<long> input)
		{
			//TODO:删除前的逻辑判断，是否允许删除
			await _bookRepository.DeleteAsync(input.Id);
		}



		/// <summary>
		/// 批量删除Book的方法
		/// </summary>
		          [AbpAuthorize(BookAppPermissions.Book_BatchDelete)]
		public async Task BatchDeleteBooksAsync(List<long> input)
		{
			//TODO:批量删除前的逻辑判断，是否允许删除
			await _bookRepository.DeleteAsync(s => input.Contains(s.Id));
		}


		/// <summary>
		/// 导出Book为excel表,等待开发。
		/// </summary>
		/// <returns></returns>
		//public async Task<FileDto> GetBooksToExcel()
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


