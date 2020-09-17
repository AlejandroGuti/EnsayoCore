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
            List<Libro> libros = await context.Libros.Include(x=>x.Autores).ToListAsync();
            /*var librosDTO = mapped.Map<List<LibroDTO>>(libros);
            var ensayo = librosDTO.FirstOrDefault(x => x.Autor.Id == 4);
            var librosDTO1 = mapped.Map<List<LibroDTO>>(ensayo);
            */

            var librosDTO = mapped.Map<List<LibroDTO>>(libros);

            //**************Para sacar lsita de nombres de autores por libro
           /* List<string> autores = new List<string>();

            foreach(Libro libro in libros)
            {
                foreach(Autor autor in libro.Autores)
                {
                    autores.Add(autor.Nombre);
                }
            }

            List<LibroDTO> model = libros.Select(l => new LibroDTO
            { 
                Autores = autores,
                AutorId = l.AutorId,
                Id = l.Id,
                Titulo = l.Titulo
            }).ToList();*/
            
            var x = librosDTO.Select(x => new  
            { 
                x.Autor.Nombre, 
                x.Autor.Id,
                x.Titulo
            }).Where(x => x.Id == 4).ToList();

            List<OtroDTO> y = new List<OtroDTO>();
        
            foreach (var k in x)
            {
                OtroDTO otroDTO = new OtroDTO();
                otroDTO.Nombre = k.Nombre;
                otroDTO.Id = k.Id;
                otroDTO.Titulo = k.Titulo;
                y.Add(otroDTO);

            }
            //var S = mapped.Map<List<OtroDTO>>(x);
            var S = mapped.Map<List<OtroDTO>>(y);
            return Ok(S);
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
