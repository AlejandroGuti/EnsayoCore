using Microsoft.EntityFrameworkCore;
using PrimerWebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerWebApi.Contexts
{
    public class AplicationDbContext: DbContext
    {
        public AplicationDbContext( DbContextOptions<AplicationDbContext> options)
            :base (options)
        {

        }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Libro> Libros { get; set; }
    }
}
