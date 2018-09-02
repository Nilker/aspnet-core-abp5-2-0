

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using XyAuto.It.Test;

namespace XyAuto.It.Books.Dtos
{
    public class CreateOrUpdateBookInput
    {
        [Required]
        public BookEditDto Book { get; set; }



		//// custom codes
 
        //// custom codes end
    }
}