using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdminPoodle.Data;
using AdminPoodle.Models;

namespace AdminPoodle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiBuyerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ApiBuyerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ApiBuyer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Buyer>>> GetBuyer()
        {
          if (_context.Buyer == null)
          {
              return NotFound();
          }
            return await _context.Buyer.ToListAsync();
        }

        // GET: api/ApiBuyer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Buyer>> GetBuyer(int id)
        {
          if (_context.Buyer == null)
          {
              return NotFound();
          }
            var buyer = await _context.Buyer.FindAsync(id);

            if (buyer == null)
            {
                return NotFound();
            }

            return buyer;
        }

        // PUT: api/ApiBuyer/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBuyer(int id, Buyer buyer)
        {
            if (id != buyer.Id)
            {
                return BadRequest();
            }

            _context.Entry(buyer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuyerExists(id))
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

        // POST: api/ApiBuyer
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Buyer>> PostBuyer(Buyer buyer)
        {
          if (_context.Buyer == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Buyer'  is null.");
          }
            _context.Buyer.Add(buyer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBuyer", new { id = buyer.Id }, buyer);
        }

        // DELETE: api/ApiBuyer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBuyer(int id)
        {
            if (_context.Buyer == null)
            {
                return NotFound();
            }
            var buyer = await _context.Buyer.FindAsync(id);
            if (buyer == null)
            {
                return NotFound();
            }

            _context.Buyer.Remove(buyer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BuyerExists(int id)
        {
            return (_context.Buyer?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
