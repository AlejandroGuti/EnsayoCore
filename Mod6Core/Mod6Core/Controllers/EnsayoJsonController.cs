using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mod6Core.Controllers
{
    [Route ("api/[controller]")]
    [ApiController]
    public class EnsayoJsonController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public EnsayoJsonController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "Valor1", "Valor2" };
        }
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id )
        {
            return configuration["Logging:LogLevel:Default"];
         //   return configuration["Apellido"];
            //return new string[] { "Valor1", "Valor2" };
        }
    }
}
