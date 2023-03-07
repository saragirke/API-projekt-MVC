using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdminPoodle.Data;
using AdminPoodle.Models;

namespace AdminPoodle.Controllers
{
    public class InterestController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InterestController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Interest
        public async Task<IActionResult> Index()
        {
              return _context.Interest != null ? 
                          View(await _context.Interest.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Interest'  is null.");
        }

        // GET: Interest/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Interest == null)
            {
                return NotFound();
            }

            var interest = await _context.Interest
                .FirstOrDefaultAsync(m => m.Id == id);
            if (interest == null)
            {
                return NotFound();
            }

            return View(interest);
        }

        // GET: Interest/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Interest/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CommenterName,Age,About,Email,DateCreated")] Interest interest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(interest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(interest);
        }

        // GET: Interest/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Interest == null)
            {
                return NotFound();
            }

            var interest = await _context.Interest.FindAsync(id);
            if (interest == null)
            {
                return NotFound();
            }
            return View(interest);
        }

        // POST: Interest/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CommenterName,Age,About,Email,DateCreated")] Interest interest)
        {
            if (id != interest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(interest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InterestExists(interest.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(interest);
        }

        // GET: Interest/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Interest == null)
            {
                return NotFound();
            }

            var interest = await _context.Interest
                .FirstOrDefaultAsync(m => m.Id == id);
            if (interest == null)
            {
                return NotFound();
            }

            return View(interest);
        }

        // POST: Interest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Interest == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Interest'  is null.");
            }
            var interest = await _context.Interest.FindAsync(id);
            if (interest != null)
            {
                _context.Interest.Remove(interest);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InterestExists(int id)
        {
          return (_context.Interest?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
