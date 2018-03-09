using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using IdentityServer4.Extensions;
using XyAuto.It.Authorization.Users.Profile.Dto;

namespace XyAuto.It.Web.Areas.AppAreaName.Models.Profile
{
    [AutoMapFrom(typeof(CurrentUserProfileEditDto))]
    public class MySettingsViewModel : CurrentUserProfileEditDto
    {
        public List<ComboboxItemDto> TimezoneItems { get; set; }

        public bool SmsVerificationEnabled { get; set; }

        public bool CanChangeUserName => UserName != AbpUserBase.AdminUserName;

        public string Code { get; set; }

        public MySettingsViewModel(CurrentUserProfileEditDto currentUserProfileEditDto)
        {
            currentUserProfileEditDto.MapTo(this);
        }

        public bool CanVerifyPhoneNumber()
        {
            return SmsVerificationEnabled && !PhoneNumber.IsNullOrEmpty() && !PhoneNumber.Trim().IsNullOrEmpty();
        }
    }
}

