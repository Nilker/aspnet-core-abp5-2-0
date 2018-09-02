

using System;
using System.Collections.Generic;
using System.Linq;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using XyAuto.It;
using XyAuto.It.Test;


namespace XyAuto.It.Books
{
    /// <summary>
    /// Book领域层的业务管理
    ///</summary>
    public class BookManager :ItDomainServiceBase, IBookManager
    {
    private readonly IRepository<Book,long> _bookRepository;

        /// <summary>
            /// Book的构造方法
            ///</summary>
        public BookManager(IRepository<Book, long>
bookRepository)
            {
            _bookRepository =  bookRepository;
            }


            /// <summary>
                ///     初始化
                ///</summary>
            public void InitBook()
            {
            throw new NotImplementedException();
            }

            //TODO:编写领域业务代码



            //// custom codes
             
            //// custom codes end

            }
            }
