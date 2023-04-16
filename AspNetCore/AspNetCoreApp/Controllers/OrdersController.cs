using Microsoft.AspNetCore.Cors;
using AspNetCoreApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspNetCoreApp.Models.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetCoreApp.Controllers
{
    [Route("api/[controller]")]
    [EnableCors]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly Context _context;

        public OrdersController(Context context)
        {
            _context = context;
        }

        // GET: 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrder()
        {
            return await _context.Order.Include(lo => lo.LineOrders).ToListAsync();
        }

        // GET: 
        [HttpGet("{number}")]
        public async Task<ActionResult<Order>> GetOrder(int number)
        {
            var order = await _context.Order.FindAsync(number);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // PUT: 
        [HttpPut("{number}")]
        public async Task<IActionResult> PutOrder(int number, Order order)
        {
            if (number != order.Number)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(number))
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

        // POST: 
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Order.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder", new {number = order.Number }, order);
        }

        // DELETE: 
        [HttpDelete("{number}")]
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteOrder(int number)
        {
            var order = await _context.Order.FindAsync(number);
            if (order == null)
            {
                return NotFound();
            }

            _context.Order.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderExists(int number)
        {
            return _context.Order.Any(e => e.Number == number);
        }
    }
}
