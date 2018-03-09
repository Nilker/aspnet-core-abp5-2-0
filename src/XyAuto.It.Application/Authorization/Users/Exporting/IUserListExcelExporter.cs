using System.Collections.Generic;
using XyAuto.It.Authorization.Users.Dto;
using XyAuto.It.Dto;

namespace XyAuto.It.Authorization.Users.Exporting
{
    public interface IUserListExcelExporter
    {
        FileDto ExportToFile(List<UserListDto> userListDtos);
    }
}
