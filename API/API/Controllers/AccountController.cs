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

namespace API.Controllers
{
    
    [ApiController]
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


        // POST: api/Account/register
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Route("api/[controller]/register")]
        [HttpPost]
        public async Task<bool> PostRegisterModel(RegisterModel registerModel)
        {
            if(ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser() { UserName = registerModel.Username, Email = registerModel.EmailAddress };
                IdentityResult result = await _userManager.CreateAsync(user, registerModel.Password);
                if(result.Succeeded)
                {
                    _context.RegisterModel.Add(registerModel);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            return false;
        }

        [Route("api/[controller]/login")]
        [HttpPost]
        [Authorize]
        public async Task<bool> PostLoginModel(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                SignInResult result = await _signInManager.PasswordSignInAsync(loginModel.Username, loginModel.Password, loginModel.RememberMe, false);

                if(result.Succeeded)
                {
                    return true;
                }
            }
            return false;
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
