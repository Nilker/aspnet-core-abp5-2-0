using XyAuto.It.Dto;

namespace XyAuto.It.Common.Dto
{
    public class FindUsersInput : PagedAndFilteredInputDto
    {
        public int? TenantId { get; set; }
    }
}
