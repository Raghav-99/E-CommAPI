using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;
using Microsoft.AspNetCore.Cors;

namespace API.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAnyOrigin")]
    public class AccountController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        
        public AccountController(AppDbContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet]
        [Route("api/[controller]/login")]
        public async Task<ActionResult<IEnumerable<IdentityUser>>> GetRegisterModel()
        {
            return await _context.Users.ToListAsync();
        }

        // POST: api/Account/register
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Route("api/[controller]/register")]
        [HttpPost]
        public async Task<int> PostRegisterModel(RegisterModel registerModel)
        {
            if(ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser() { UserName = registerModel.Username, Email = registerModel.EmailAddress };
                IdentityResult result = await _userManager.CreateAsync(user, registerModel.Password);
                if(result.Succeeded)
                {
                    _context.RegisterModel.Add(registerModel);
                    await _context.SaveChangesAsync();
                    return StatusCodes.Status201Created;
                }
                return StatusCodes.Status406NotAcceptable;
            }
            return StatusCodes.Status400BadRequest;
        }

        [Route("api/[controller]/login")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<int> PostLoginModel(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                SignInResult result = await _signInManager.PasswordSignInAsync(loginModel.Username, loginModel.Password, loginModel.RememberMe, false);

                if(result.Succeeded)
                {
                    return StatusCodes.Status200OK;
                }
                return StatusCodes.Status401Unauthorized;
            }
            return StatusCodes.Status400BadRequest;
        }

        // DELETE: api/Register/5
        [HttpDelete("api/[controller]/{id}")]
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
