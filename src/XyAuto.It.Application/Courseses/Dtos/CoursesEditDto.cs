

using System;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;
using XyAuto.It.Test;

namespace  XyAuto.It.Courseses.Dtos
{
    public class CoursesEditDto
    {
/// <summary>
/// Id
/// </summary>
public int? Id { get; set; }


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