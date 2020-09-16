using Alone.Contexts;
using Alone.Entities;
using Alone.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Alone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController:ControllerBase
    {

 
        private readonly ApplicationDbContext context;
        private readonly IMapper mapped;

        public LibrosController(ApplicationDbContext context, IMapper mapped)
        {
            this.context = context;
            this.mapped = mapped;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LibroDTO>>> Get()
        {
            var libros = await context.Libros.ToListAsync();
            var librosDTO = mapped.Map<List<LibroDTO>>(libros);
            return librosDTO;
        }
        [HttpGet("{id}",Name ="SearchLibro")]
        public async Task<ActionResult<LibroDTO>> Get(int id)
        {
            var libros = await context.Libros.FirstOrDefaultAsync(x=>x.Id==id);
            if (libros == null) { return NotFound(); }
            var libroDTO=mapped.Map<LibroDTO>(libros);
            return libroDTO;
        }

        [HttpPost]
        public async Task<ActionResult> Post(LibroDTO libroDTO)
        {
            var libro = mapped.Map<Libro>(libroDTO);
            context.Add(libro);
            await context.SaveChangesAsync();
            libroDTO = mapped.Map<LibroDTO>(libro);
            return new CreatedAtRouteResult("SearchLibro", new { id = libro.Id }, libroDTO);


        }

    }
}
