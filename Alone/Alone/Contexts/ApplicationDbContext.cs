using Alone.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alone.Contexts
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<Autor> Autors { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Cosa> CosaAs { get; set; }
        public DbSet<CosaACosaB> CosaACosaBs { get; set; }
        public DbSet<CosaB> CosaBs { get; set; }
    }
}
