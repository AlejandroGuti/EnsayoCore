using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mod5Core.Models
{
    public class AutorCreacionDTO
    {

        [Required]
        public string Name { get; set; }
        //public string Identification { get; set; }
        public DateTime BornDate { get; set; }


    }
}
