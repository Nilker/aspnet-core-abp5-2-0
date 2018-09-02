

using System;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using XyAuto.It.Test;

namespace XyAuto.It.Courseses.Dtos
{
    public class CoursesListDto : EntityDto<int>
    {

/// <summary>
/// CoursesID
/// </summary>
public int CoursesID { get; set; }


/// <summary>
/// CourseName
/// </summary>
public string CourseName { get; set; }


/// <summary>
/// Standard
/// </summary>
public string Standard { get; set; }






		//// custom codes
 
        //// custom codes end
    }
}