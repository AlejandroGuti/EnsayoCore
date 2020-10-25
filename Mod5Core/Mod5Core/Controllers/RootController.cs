using Microsoft.AspNetCore.Mvc;
using Mod5Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mod5Core.Controllers
{
    [Route("api")]
    [ApiController]
    public class RootController:ControllerBase
    {

        public RootController()
        {
            
        }

        [HttpGet(Name = "GetRoot")]
        public ActionResult<IEnumerable<Enlace>> Get()
        {
            List<Enlace> enlaces = new List<Enlace>();
            //Aqui coloca los links 
            enlaces.Add(new Enlace(href: Url.Link("GetRoot",new { }),rel:"self",method:"GET"));
            enlaces.Add(new Enlace(href: Url.Link("CreateAutor", new { }), rel: "Create_Autores", method: "POST"));
            enlaces.Add(new Enlace(href: Url.Link("ListAutores", new { }), rel: "Obtain_Autores", method: "GET"));
           return enlaces;
        }
    }
}
