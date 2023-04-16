using AspNetCoreApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspNetCoreApp.Models.DTO;
using Microsoft.Extensions.Hosting;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetCoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinesOrderController : ControllerBase
    {
        private readonly Context _context;

        public LinesOrderController(Context context)
        {
            _context = context;
        }

        // GET: 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LineOrder>>> GetLineOrder()
        {
            return await _context.LineOrder.ToListAsync();
        }

        // GET: 
        [HttpGet("{number}")]
        public async Task<ActionResult<LineOrder>> GetLineOrder(int ID)
        {
            var lineorder = await _context.LineOrder.FindAsync(ID);

            if (lineorder == null)
            {
                return NotFound();
            }

            return lineorder;
        }

        // PUT: 
        [HttpPut("{number}")]
        public async Task<IActionResult> Putlineorder(int ID, LineOrder lineorder)
        {
            if (ID != lineorder.ID)
            {
                return BadRequest();
            }

            _context.Entry(lineorder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!lineorderExists(ID))
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
        public async Task<ActionResult<LineOrder>> PostLineorder(LineOrderDTO lineorderDTO)
        {
            if (_context.LineOrder == null)
            {
                return Problem("Entity set is null.");
            }
            var lineorder = new LineOrder
            {
                Name = lineorderDTO.Name,
                PurchasePrice = lineorderDTO.PurchasePrice,
                CountOrder = lineorderDTO.CountOrder,
                NumberOrder_FK_ = lineorderDTO.NumberOrder_FK_
            };
            _context.LineOrder.Add(lineorder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getlineorder", new { iD  = lineorder.ID }, lineorder);
        }

        // DELETE: 
        [HttpDelete("{number}")]
        public async Task<IActionResult> Deletelineorder(int ID)
        {
            var lineorder = await _context.LineOrder.FindAsync(ID);
            if (lineorder == null)
            {
                return NotFound();
            }

            _context.LineOrder.Remove(lineorder);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool lineorderExists(int ID)
        {
            return _context.LineOrder.Any(e => e.ID == ID);
        }
    }
}
