using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Mod7._2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mod7._2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("PermitirAPIIO")]//Acepta paginas externas
    public class ValuesController:ControllerBase
    {
        private readonly IDataProtector _protector;
        private readonly HashService _hashService;

        public ValuesController(IDataProtectionProvider protectionProvider, HashService hashService)
        {
            _protector = protectionProvider.CreateProtector("Unique_Value_And_Maybe_Secret");
            _hashService = hashService;
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "Valu1", "Value2" }; 
        }
       [HttpGet("Other")]
        public ActionResult<IEnumerable<string>> GetOther()
        {
            var texto = "Holi";
            var A= new string[] { texto, _protector.Protect(texto),_protector.Unprotect(_protector.Protect(texto)) };
            return Ok(A) ;
        }
        [HttpGet("Hash")]
        public ActionResult<IEnumerable<string>> GetHash()
        {
            var texto = "Holi";
            var A = new string[] {_hashService.Hash(texto).Hash, _hashService.Hash(texto).Hash, };
            return Ok(A);
        }

    }
}
