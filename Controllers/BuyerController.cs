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
    public class BuyerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BuyerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Buyer
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Buyer.Include(b => b.Pup);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Buyer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Buyer == null)
            {
                return NotFound();
            }

            var buyer = await _context.Buyer
                .Include(b => b.Pup)
                .FirstOrDefaultAsync(m => m.Id == id);

                
            if (buyer == null)
            {
                return NotFound();
            }

            return View(buyer);
        }

        // GET: Buyer/Create
        public IActionResult Create()
        {

            //Hämta valpar som inte redan är tingade
            var pupContext = _context.Pup.Where(s => s.Booked == false)
            .Select(s => s)
            .ToList();

            ViewData["PupId"] = new SelectList(pupContext, "Id", "Title");
            return View();
        }

        // POST: Buyer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,Number,PupId")] Buyer buyer)
        {
            if (ModelState.IsValid)
            {


                // Hämtar valpens id
                var getPup =
                   from s in _context.Pup
                   where s.Id == buyer.PupId
                   select s;

                // Ändrar status till booked
                foreach (var s in getPup)
                {
                    s.Booked = true;
                }


                _context.Add(buyer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PupId"] = new SelectList(_context.Pup, "Id", "Title", buyer.PupId);
            return View(buyer);
        }

        // GET: Buyer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Buyer == null)
            {
                return NotFound();
            }

            var buyer = await _context.Buyer.FindAsync(id);
            if (buyer == null)
            {
                return NotFound();
            }

          
            //Hämta valpar som inte redan är tingade
            var pupContext = _context.Pup
            .Where(s => s.Booked == false)
            .Select(s => s)
            .ToList();

              var puppy =_context.Pup
              .Where(s => s.Id == buyer.PupId)
              .Select(s => s)
              .FirstOrDefault();

              if(puppy != null)
              {
                pupContext.Add(puppy);
              }

            ViewData["PupId"] = new SelectList(pupContext, "Id", "Title", buyer.PupId);
            return View(buyer);
        }

        // POST: Buyer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email,Number,PupId")] Buyer buyer)
        {
            if (id != buyer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(buyer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuyerExists(buyer.Id))
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
            ViewData["PupId"] = new SelectList(_context.Pup, "Id", "Gender", buyer.PupId);
            return View(buyer);
        }

        // GET: Buyer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Buyer == null)
            {
                return NotFound();
            }
            

            var buyer = await _context.Buyer
                .Include(b => b.Pup)
                .FirstOrDefaultAsync(m => m.Id == id);


                // Hämtar valp med samma ID
                var getPup =
                   from s in _context.Pup
                   where s.Id == buyer.PupId
                   select s;

                // Ändrar status till booked
                foreach (var s in getPup)
                {
                    s.Booked = false;
                }




            if (buyer == null)
            {
                return NotFound();
            }

            return View(buyer);
        }

        // POST: Buyer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Buyer == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Buyer'  is null.");
            }
            var buyer = await _context.Buyer.FindAsync(id);
            if (buyer != null)
            {
                _context.Buyer.Remove(buyer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BuyerExists(int id)
        {
          return (_context.Buyer?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}