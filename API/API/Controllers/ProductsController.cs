using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API;
using Microsoft.AspNetCore.Cors;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAnyOrigin")]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductsModel>>> GetProductsModel()
        {
            return await _context.ProductsModel.ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductsModel>> GetProductsModel(int id)
        {
            var productsModel = await _context.ProductsModel.FindAsync(id);

            if (productsModel == null)
            {
                return NotFound();
            }

            return productsModel;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductsModel(int id, ProductsModel productsModel)
        {
            if (id != productsModel.PId)
            {
                return BadRequest();
            }

            _context.Entry(productsModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductsModelExists(id))
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

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductsModel>> PostProductsModel(ProductsModel productsModel)
        {
            _context.ProductsModel.Add(productsModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductsModel", new { id = productsModel.PId }, productsModel);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductsModel(int id)
        {
            var productsModel = await _context.ProductsModel.FindAsync(id);
            if (productsModel == null)
            {
                return NotFound();
            }

            _context.ProductsModel.Remove(productsModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductsModelExists(int id)
        {
            return _context.ProductsModel.Any(e => e.PId == id);
        }
    }
}
