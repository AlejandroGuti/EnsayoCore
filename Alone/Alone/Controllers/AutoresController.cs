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
    public class AutoresController:ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapped;

        public AutoresController(ApplicationDbContext context, IMapper mapped)
        {
            this.context = context;
            this.mapped = mapped;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AutorDTO>>> Get()
        {
            var Autores = await context.Autors.ToListAsync();
            var autoresDTO = mapped.Map<List<AutorDTO>>(Autores);
            return autoresDTO;
        }
        [HttpGet("{id}", Name = "SearchOne")]
        public async Task<ActionResult<AutorDTO>> Get(int id, string param2)
        {
            var autor = await context.Autors.FirstOrDefaultAsync(x=>x.Id==id);
            if (autor == null) { return NotFound(); }
            var autorDTO = mapped.Map<AutorDTO>(autor);
            return autorDTO;
        }
        [HttpPost]
        public async Task<ActionResult> Post(AutorDTO autorDTO)
        {
            var autor = mapped.Map<Autor>(autorDTO);
            await context.AddAsync(autor);
            await context.SaveChangesAsync();
            autorDTO = mapped.Map<AutorDTO>(autor);
            return new CreatedAtRouteResult("SearchOne", new { id = autor.Id }, autorDTO);
        }

    }
}
