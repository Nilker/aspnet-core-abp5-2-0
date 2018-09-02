

using System;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using XyAuto.It.Test;

namespace XyAuto.It.Books.Dtos
{
    public class BookListDto : EntityDto<long>
    {

/// <summary>
/// Name
/// </summary>
[MaxLength(2147483647, ErrorMessage="Name超出最大长度")]
[Required(ErrorMessage="Name不能为空")]
public string Name { get; set; }


/// <summary>
/// Surname
/// </summary>
[MaxLength(2147483647, ErrorMessage="Surname超出最大长度")]
[Required(ErrorMessage="Surname不能为空")]
public string Surname { get; set; }


/// <summary>
/// EmailAddress
/// </summary>
[MaxLength(2147483647, ErrorMessage="EmailAddress超出最大长度")]
public string EmailAddress { get; set; }






		//// custom codes
 
        //// custom codes end
    }
}