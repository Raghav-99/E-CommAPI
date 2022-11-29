using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API;
using Microsoft.AspNetCore.Cors;
using System.Net;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAnyOrigin")]
    public class SellerController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SellerController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Seller
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SellerModel>>> GetSellerModel()
        {
            return await _context.SellerModel.ToListAsync();
        }

        // GET: api/Seller/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SellerModel>> GetSellerModel(string id)
        {
            var sellerModel = await _context.SellerModel.FindAsync(id);

            if (sellerModel == null)
            {
                return NotFound();
            }

            return sellerModel;
        }

        // PUT: api/Seller/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSellerModel(string id, SellerModel sellerModel)
        {
            if (id != sellerModel.Sellername)
            {
                return BadRequest();
            }

            _context.Entry(sellerModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SellerModelExists(id))
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

        // POST: api/Seller
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HttpStatusCode>> PostSellerModel(SellerModel sellerModel)
        {
            _context.SellerModel.Add(sellerModel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SellerModelExists(sellerModel.Sellername))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return HttpStatusCode.Created;
        }

        // DELETE: api/Seller/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSellerModel(string id)
        {
            var sellerModel = await _context.SellerModel.FindAsync(id);
            if (sellerModel == null)
            {
                return NotFound();
            }

            _context.SellerModel.Remove(sellerModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SellerModelExists(string id)
        {
            return _context.SellerModel.Any(e => e.Sellername == id);
        }
    }
}
