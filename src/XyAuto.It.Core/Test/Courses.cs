using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XyAuto.It.Test
{
    public class Courses :Entity<int>
    {
        [Key]
        public int CoursesID { get; set; }
        public string CourseName { get; set; }
        public string Standard { get; set; }

        protected Courses() { }
    }
}
