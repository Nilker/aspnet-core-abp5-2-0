using Abp.Notifications;
using XyAuto.It.Dto;

namespace XyAuto.It.Notifications.Dto
{
    public class GetUserNotificationsInput : PagedInputDto
    {
        public UserNotificationState? State { get; set; }
    }
}
