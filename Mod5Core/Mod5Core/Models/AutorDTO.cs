using Mod5Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mod5Core.Models
{
    public class AutorDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        //public string Identification { get; set; }
        public DateTime BornDate { get; set; }

        public List<LibroDTO> Books { get; set; }
    }
}
