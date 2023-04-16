using Microsoft.AspNetCore.Cors;
using AspNetCoreApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetCoreApp.Controllers
{
    [Route("api/[controller]")]
    [EnableCors]
    [ApiController]
    public class WritesController : ControllerBase
    {
        private readonly Context _context;

        public WritesController(Context context)
        {
            _context = context;
        }

        // GET:
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Write>>> GetWrite()
        {
            return await _context.Write.Include(lo => lo.LineWrites).ToListAsync();
        }

        // GET:
        [HttpGet("{number}")]
        public async Task<ActionResult<Write>> GetWrite(int number)
        {
            var write = await _context.Write.FindAsync(number);

            if (write == null)
            {
                return NotFound();
            }

            return write;
        }

        // PUT: 
        [HttpPut("{number}")]
        public async Task<IActionResult> PutWrite(int number, Write write)
        {
            if (number != write.NumberAct)
            {
                return BadRequest();
            }

            _context.Entry(write).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WriteExists(number))
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
        public async Task<ActionResult<Write>> LineWrite(Write write)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Write.Add(write);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder", new { number = write.NumberAct }, write);
        }

        // DELETE: 
        [HttpDelete("{number}")]
        public async Task<IActionResult> DeleteWrite(int number)
        {
            var write = await _context.Write.FindAsync(number);
            if (write == null)
            {
                return NotFound();
            }

            _context.Write.Remove(write);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WriteExists(int number)
        {
            return _context.Write.Any(e => e.NumberAct == number);
        }
    }
}
