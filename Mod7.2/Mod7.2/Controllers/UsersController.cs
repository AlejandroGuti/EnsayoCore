using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Mod7._2.Contexts;
using Mod7._2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Mod7._2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController:ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        [HttpPost("AsignRolToUser")]
        public async Task<ActionResult> AsignRolToUser(EditRolDTO editRolDTO)
        {
            var user = await _userManager.FindByIdAsync(editRolDTO.UserId);
            if (user== null)
            {
                return NotFound();
            }
            await _userManager.AddClaimAsync(
                user, new Claim(ClaimTypes.Role, editRolDTO.RolName)
                );
            await _userManager.AddToRoleAsync(user, editRolDTO.RolName);
            return Ok();

        }
        [HttpPost("RemoveRolToUser")]
        public async Task<ActionResult> RemoveRolToUser(EditRolDTO editRolDTO)
        {
            var user = await _userManager.FindByIdAsync(editRolDTO.UserId);
            if (user == null)
            {
                return NotFound();
            }
            await _userManager.RemoveClaimAsync(
                user, new Claim(ClaimTypes.Role, editRolDTO.RolName)
                );
            await _userManager.RemoveFromRoleAsync(user, editRolDTO.RolName);
            return Ok();

        }
    }
}
