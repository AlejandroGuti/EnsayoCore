using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMod7Core.Contexts;

namespace UserMod7Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //Pueden todos los loggeados [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles ="admin")]

    public class ValuesController:ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ValuesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]

        public ActionResult<IEnumerable<string>> Get()
        {
            string[] weekDays = new string[] { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
            return weekDays;
        }

    }
}
