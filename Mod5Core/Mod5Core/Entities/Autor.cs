using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mod5Core.Entities
{
    public class Autor
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Identification { get; set; }
        public DateTime BornDate { get; set; }

        public List<Libro> Books { get; set; }
    }
}
