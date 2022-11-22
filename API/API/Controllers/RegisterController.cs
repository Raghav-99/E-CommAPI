using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API;
using Microsoft.AspNetCore.Identity;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly AppDbContext _context;
        private UserManager<IdentityUser> _userManager;

        public RegisterController(AppDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
/*
        [HttpGet]
        [ActionName("GetUser")]
        public async Task<ActionResult<IEnumerable<RegisterModel>>> GetUser()
        {
            return await _context.RegisterModel.ToListAsync();
        }*/

        // POST: api/Register
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RegisterModel>> PostRegisterModel(RegisterModel registerModel)
        {
            if(ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser() { UserName = registerModel.Username, Email = registerModel.EmailAddress };
                IdentityResult result = await _userManager.CreateAsync(user, registerModel.Password);
                if(result.Succeeded)
                {
                    _context.RegisterModel.Add(registerModel);
                    await _context.SaveChangesAsync();
                    //return CreatedAtAction("GetUser", new {user = registerModel.Username}, user);
                }
                else
                    return BadRequest(result);
            }
            return BadRequest(ModelState);
        }

        // DELETE: api/Register/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegisterModel(string id)
        {
            var registerModel = await _context.RegisterModel.FindAsync(id);
            if (registerModel == null)
            {
                return NotFound();
            }

            _context.RegisterModel.Remove(registerModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RegisterModelExists(string id)
        {
            return _context.RegisterModel.Any(e => e.Username == id);
        }
    }
}
