using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XyAuto.It.Test
{
    public class Book : Entity<long>
    {

        [Required]
        [MaxLength(32)]
        public virtual string Name { get; set; }

        [Required]
        [MaxLength(32)]
        public virtual string Surname { get; set; }

        [MaxLength(255)]
        public virtual string EmailAddress { get; set; }
    }
}
