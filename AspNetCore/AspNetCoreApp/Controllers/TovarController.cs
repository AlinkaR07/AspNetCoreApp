using Microsoft.AspNetCore.Cors;
using AspNetCoreApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspNetCoreApp.Models.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace AspNetCoreApp.Controllers
{
    [Route("api/[controller]")]
    [EnableCors]
    [ApiController]
    public class TovarController : ControllerBase
    {
        private readonly Context _context;

        public TovarController(Context context)
        {
            _context = context;
        }

        // GET: 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tovar>>> GetTovar()
        {
            return await _context.Tovar.ToListAsync();
        }

        // GET: 
        [HttpGet("{number}")]
        public async Task<ActionResult<Tovar>> GetTovar(int cod)
        {
            var tovar = await _context.Tovar.FindAsync(cod);

            if (tovar == null)
            {
                return NotFound();
            }

            return tovar;
        }

        // PUT: 
        [HttpPut("{number}")]
        public async Task<IActionResult> PutTovar(int cod, Tovar tovar)
        {
            if (cod != tovar.CodTovara)
            {
                return BadRequest();
            }

            _context.Entry(tovar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TovarExists(cod))
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
        public async Task<ActionResult<Tovar>> PostTovar(Tovar tovar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Tovar.Add(tovar);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTovar", new { cod = tovar.CodTovara }, tovar);
        }

        // DELETE: 
        [HttpDelete("{cod}")]
        public async Task<IActionResult> DeleteTovar(int cod)
        {
            var tovar = await _context.Tovar.FindAsync(cod);
            if (tovar == null)
            {
                return NotFound();
            }

            _context.Tovar.Remove(tovar);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TovarExists(int cod)
        {
            return _context.Tovar.Any(e => e.CodTovara == cod);
        }
    }
}
