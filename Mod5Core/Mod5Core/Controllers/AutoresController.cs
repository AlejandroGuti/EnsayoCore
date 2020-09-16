using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mod5Core.Contexts;
using Mod5Core.Entities;
using Mod5Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mod5Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public AutoresController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        /*
          [HttpGet("/primero")]
          public ActionResult<Autor> GetPrimerAutor()
          {
              return context.Autores.FirstOrDefault();
          }*/
        /**/
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AutorDTO>>> Get()
        {
            var autores = await context.Autores.ToListAsync();
            var autoresDTO = mapper.Map<List<AutorDTO>>(autores);
            return autoresDTO;
        }

        [HttpGet("{id}", Name = "ObtenerAutor")]
        public async Task<ActionResult<AutorDTO>> Get(int id, string param2)
        {
            Autor autor = await context.Autores.FirstOrDefaultAsync(x => x.Id == id);
            if (autor == null)
            {
                return NotFound();
            }
            AutorDTO autorDTO = mapper.Map<AutorDTO>(autor);
            return autorDTO;

        }
         [HttpPost]
         public async Task<ActionResult> Post([FromBody] AutorCreacionDTO autorCreationDTO)
         {
            var autor = mapper.Map<Autor>(autorCreationDTO);
             context.Add(autor);
             await context.SaveChangesAsync();
            var autorDTO = mapper.Map<AutorDTO>(autor);
             return new CreatedAtRouteResult("ObtenerAutor", new { id = autor.Id }, autorDTO);

         }
        
         [HttpPut("{id}")]
         public async Task<ActionResult> Put(int id, [FromBody] AutorActualizactionDTO autorActualization)
         {
            var autor = mapper.Map<Autor>(autorActualization);
            autor.Id = id;
             context.Entry(autor).State = EntityState.Modified;
             await context.SaveChangesAsync();
             return NoContent();
        }
        [HttpPatch("{id}")]

        public async Task<ActionResult> Patch
            (int id, [FromBody] JsonPatchDocument<AutorActualizactionDTO> patchDocument) 
        {
        if(patchDocument == null)
            {
                return BadRequest();
            }
            var autorDeLaBd = await context.Autores.FirstOrDefaultAsync(x=>x.Id==id);
            if (autorDeLaBd == null)
            {
                return NotFound();
            }
            var autorDTO = mapper.Map<AutorActualizactionDTO>(autorDeLaBd);
            patchDocument.ApplyTo(autorDTO, ModelState);
            mapper.Map(autorDTO, autorDeLaBd);
            var isValid = TryValidateModel(autorDeLaBd);
            if (!isValid) { return BadRequest(ModelState); }

            await context.SaveChangesAsync();
            return NoContent();
        }
        
        
         [HttpDelete("{id}")]
         public async Task<ActionResult<Autor>> Delete(int id)
         {

            var autorID = await context.Autores.Select(x=>x.Id).FirstOrDefaultAsync(x => x == id);

            /*var autorID = await context.Autores.FirstOrDefaultAsync(x => x.Id == id);
            
           if (autorID == null)
            {
                return NotFound();
            }
            var autorID2 = mapper.Map<AutorDeleteDTO>(autorID);
            mapper.Map(autorID2, autorID);
            context.Autores.Remove(new Autor { Id = autorID.Id });
    
            await context.SaveChangesAsync();
            return NoContent();*/
            if (autorID == default(int))
             {
                 return NotFound();
             }
            //var autorDelDTO = mapper.Map<AutorDeleteDTO>(autorID); 
             context.Autores.Remove(new Autor { Id=autorID});
             await context.SaveChangesAsync();
             return NoContent();

        }
    }
}
