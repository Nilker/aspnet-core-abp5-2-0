

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using XyAuto.It.Test;

namespace XyAuto.It.Courseses.Dtos
{
    public class CreateOrUpdateCoursesInput
    {
        [Required]
        public CoursesEditDto Courses { get; set; }



		//// custom codes
 
        //// custom codes end
    }
}