

using System;
using System.Collections.Generic;
using System.Linq;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using XyAuto.It;
using XyAuto.It.Test;


namespace XyAuto.It.Courseses
{
    /// <summary>
    /// Courses领域层的业务管理
    ///</summary>
    public class CoursesManager :ItDomainServiceBase, ICoursesManager
    {
    private readonly IRepository<Courses,int> _coursesRepository;

        /// <summary>
            /// Courses的构造方法
            ///</summary>
        public CoursesManager(IRepository<Courses, int>
coursesRepository)
            {
            _coursesRepository =  coursesRepository;
            }


            /// <summary>
                ///     初始化
                ///</summary>
            public void InitCourses()
            {
            throw new NotImplementedException();
            }

            //TODO:编写领域业务代码



            //// custom codes
             
            //// custom codes end

            }
            }
