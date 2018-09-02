

using AutoMapper;
using XyAuto.It.Books;
using XyAuto.It.Test;

namespace XyAuto.It.Books.Dtos.CustomMapper
{

    /// <summary>
    /// 配置Book的AutoMapper
    ///</summary>
    internal static class CustomerBookMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Book, BookListDto>
    ();
            configuration.CreateMap<BookEditDto, Book>
                ();



            //// custom codes

            //// custom codes end

        }
    }
}
