using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAnyOrigin")]
    public class CommodityMapController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CommodityMapController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/CommodityMap
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommodityMapModel>>> GetCommodityMapModel()
        {
            return await _context.CommodityMapModel.ToListAsync();
        }

        // GET: api/CommodityMap/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductsModel>> GetCommodityMapModel(int id)
        {
            var commodityMapModel = await _context.CommodityMapModel.FindAsync(id);
            var getProduct = await _context.ProductsModel.FindAsync(commodityMapModel.PId);

            if (commodityMapModel == null || getProduct == null)
            {
                return NotFound();
            }

            return getProduct;
        }

        [Route("getallsellers")]
        [HttpGet]
        public IQueryable<CommodityMapModel> FindAllSellersByProductId([FromQuery]int id)
        {
            var commodityMapModel = _context.CommodityMapModel.Find(id);
            var getSellers = _context.CommodityMapModel.Where(x => x.PId == id);
            return getSellers;
        }

        // PUT: api/CommodityMap/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommodityMapModel(int id, CommodityMapModel commodityMapModel)
        {
            if (id != commodityMapModel.CId)
            {
                return BadRequest();
            }

            _context.Entry(commodityMapModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommodityMapModelExists(id))
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

        // POST: api/CommodityMap
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CommodityMapModel>> PostCommodityMapModel(CommodityMapModel commodityMapModel)
        {
            _context.CommodityMapModel.Add(commodityMapModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCommodityMapModel", new { id = commodityMapModel.CId }, commodityMapModel);
        }

        // DELETE: api/CommodityMap/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommodityMapModel(int id)
        {
            var commodityMapModel = await _context.CommodityMapModel.FindAsync(id);
            if (commodityMapModel == null)
            {
                return NotFound();
            }

            _context.CommodityMapModel.Remove(commodityMapModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CommodityMapModelExists(int id)
        {
            return _context.CommodityMapModel.Any(e => e.CId == id);
        }
    }
}
