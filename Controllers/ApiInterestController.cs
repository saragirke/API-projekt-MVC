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
    public class ApiInterestController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ApiInterestController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ApiInterest
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Interest>>> GetInterest()
        {
          if (_context.Interest == null)
          {
              return NotFound();
          }
            return await _context.Interest.ToListAsync();
        }

        // GET: api/ApiInterest/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Interest>> GetInterest(int id)
        {
          if (_context.Interest == null)
          {
              return NotFound();
          }
            var interest = await _context.Interest.FindAsync(id);

            if (interest == null)
            {
                return NotFound();
            }

            return interest;
        }

        // PUT: api/ApiInterest/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInterest(int id, Interest interest)
        {
            if (id != interest.Id)
            {
                return BadRequest();
            }

            _context.Entry(interest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InterestExists(id))
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

        // POST: api/ApiInterest
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Interest>> PostInterest(Interest interest)
        {
          if (_context.Interest == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Interest'  is null.");
          }
            _context.Interest.Add(interest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInterest", new { id = interest.Id }, interest);
        }

        // DELETE: api/ApiInterest/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInterest(int id)
        {
            if (_context.Interest == null)
            {
                return NotFound();
            }
            var interest = await _context.Interest.FindAsync(id);
            if (interest == null)
            {
                return NotFound();
            }

            _context.Interest.Remove(interest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InterestExists(int id)
        {
            return (_context.Interest?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
