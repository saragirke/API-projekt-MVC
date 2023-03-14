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
    public class ApiPupController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ApiPupController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ApiPup
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pup>>> GetPup()
        {
          if (_context.Pup == null)
          {
              return NotFound();
          }
            return await _context.Pup.ToListAsync();
        }

        // GET: api/ApiPup/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pup>> GetPup(int id)
        {
          if (_context.Pup == null)
          {
              return NotFound();
          }
            var pup = await _context.Pup.FindAsync(id);

            if (pup == null)
            {
                return NotFound();
            }

            return pup;
        }

        // PUT: api/ApiPup/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPup(int id, Pup pup)
        {
            if (id != pup.Id)
            {
                return BadRequest();
            }

            _context.Entry(pup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PupExists(id))
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

        // POST: api/ApiPup
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pup>> PostPup(Pup pup)
        {
          if (_context.Pup == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Pup'  is null.");
          }
            _context.Pup.Add(pup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPup", new { id = pup.Id }, pup);
        }

        // DELETE: api/ApiPup/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePup(int id)
        {
            if (_context.Pup == null)
            {
                return NotFound();
            }
            var pup = await _context.Pup.FindAsync(id);
            if (pup == null)
            {
                return NotFound();
            }

            _context.Pup.Remove(pup);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PupExists(int id)
        {
            return (_context.Pup?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
