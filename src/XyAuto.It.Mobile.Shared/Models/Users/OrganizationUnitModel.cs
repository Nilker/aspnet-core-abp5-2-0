using Abp.AutoMapper;
using XyAuto.It.Organizations.Dto;

namespace XyAuto.It.Models.Users
{
    [AutoMapFrom(typeof(OrganizationUnitDto))]
    public class OrganizationUnitModel : OrganizationUnitDto
    {
        public bool IsAssigned { get; set; }
    }
}
