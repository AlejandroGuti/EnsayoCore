using Alone.Contexts;
using Alone.Entities;
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
    public class CosaController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapped;

        public CosaController(ApplicationDbContext context, IMapper mapped)
        {
            this.context = context;
            this.mapped = mapped;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cosa>>> Get()
        {
            Cosa consulta = await context.CosaAs
                .Include(ca => ca.CosaACosaB)
                .ThenInclude(cab => cab.CosaB)
                .FirstOrDefaultAsync(ca => ca.id == 1);

           // var qry = context.CosaAs.FromSql("Select * from CosaAs");
           // ViewCom gfy= consulta
            //var autoresDTO = mapped.Map<List<AutorDTO>>(Autores);
            return Ok(consulta);

        }
    }
}
