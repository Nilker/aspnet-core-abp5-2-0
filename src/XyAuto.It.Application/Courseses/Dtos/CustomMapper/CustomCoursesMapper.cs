

using AutoMapper;
using XyAuto.It.Courseses;
using XyAuto.It.Test;

namespace XyAuto.It.Courseses.Dtos.CustomMapper
{

	/// <summary>
    /// 配置Courses的AutoMapper
    ///</summary>
	internal static class CustomerCoursesMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <Courses, CoursesListDto>
    ();
    configuration.CreateMap <CoursesEditDto, Courses>
        ();



        //// custom codes
         
        //// custom codes end

        }
        }
        }
