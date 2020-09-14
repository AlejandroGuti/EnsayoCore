using Mod5Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mod5Core.Models
{
    public class LibroDTO
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int AutorId { get; set; }
        //public Autor Autor { get; set; }
    }
}
