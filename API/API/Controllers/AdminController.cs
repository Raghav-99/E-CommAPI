using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AdminController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Admin
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdminModel>>> GetAdminModel()
        {
            return await _context.AdminModel.ToListAsync();
        }

        // GET: api/Admin/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AdminModel>> GetAdminModel(string id)
        {
            var adminModel = await _context.AdminModel.FindAsync(id);

            if (adminModel == null)
            {
                return NotFound();
            }

            return adminModel;
        }

        // PUT: api/Admin/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdminModel(string id, AdminModel adminModel)
        {
            if (id != adminModel.UserName)
            {
                return BadRequest();
            }

            _context.Entry(adminModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdminModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Admin
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AdminModel>> PostAdminModel(AdminModel adminModel)
        {
            _context.AdminModel.Add(adminModel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AdminModelExists(adminModel.UserName))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAdminModel", new { id = adminModel.UserName }, adminModel);
        }

        // DELETE: api/Admin/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdminModel(string id)
        {
            var adminModel = await _context.AdminModel.FindAsync(id);
            if (adminModel == null)
            {
                return NotFound();
            }

            _context.AdminModel.Remove(adminModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdminModelExists(string id)
        {
            return _context.AdminModel.Any(e => e.UserName == id);
        }
    }
}
