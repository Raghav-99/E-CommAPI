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
    public class OrderHistoryController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrderHistoryController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/OrderHistory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderHistoryModel>>> GetOrderHistoryModel()
        {
            return await _context.OrderHistoryModel.ToListAsync();
        }

        // GET: api/OrderHistory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderHistoryModel>> GetOrderHistoryModel(int id)
        {
            var orderHistoryModel = await _context.OrderHistoryModel.FindAsync(id);

            if (orderHistoryModel == null)
            {
                return NotFound();
            }

            return orderHistoryModel;
        }

        // PUT: api/OrderHistory/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderHistoryModel(int id, OrderHistoryModel orderHistoryModel)
        {
            if (id != orderHistoryModel.OrderId)
            {
                return BadRequest();
            }

            _context.Entry(orderHistoryModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderHistoryModelExists(id))
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

        // POST: api/OrderHistory
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderHistoryModel>> PostOrderHistoryModel(OrderHistoryModel orderHistoryModel)
        {
            _context.OrderHistoryModel.Add(orderHistoryModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderHistoryModel", new { id = orderHistoryModel.OrderId }, orderHistoryModel);
        }

        // DELETE: api/OrderHistory/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderHistoryModel(int id)
        {
            var orderHistoryModel = await _context.OrderHistoryModel.FindAsync(id);
            if (orderHistoryModel == null)
            {
                return NotFound();
            }

            _context.OrderHistoryModel.Remove(orderHistoryModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderHistoryModelExists(int id)
        {
            return _context.OrderHistoryModel.Any(e => e.OrderId == id);
        }
    }
}
