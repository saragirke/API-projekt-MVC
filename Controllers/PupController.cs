using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdminPoodle.Data;
using AdminPoodle.Models;
using LazZiya.ImageResize; // Bilder
using System.Drawing; // Bilder

namespace AdminPoodle.Controllers
{
    public class PupController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        private string wwwRootPath;

                //Bilder
        private int ImageWidth= 640;
        private int ImageHeigth= 420;


        public PupController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
            wwwRootPath = _hostEnvironment.WebRootPath;
        }

        // GET: Pup
        public async Task<IActionResult> Index()
        {
              return _context.Pup != null ? 
                          View(await _context.Pup.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Pup'  is null.");
        }

        // GET: Pup/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pup == null)
            {
                return NotFound();
            }

            var pup = await _context.Pup
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pup == null)
            {
                return NotFound();
            }

            return View(pup);
        }

        // GET: Pup/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pup/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Gender,Booked,ImageFile")] Pup pup)
        {
            if (ModelState.IsValid)
            {

                 if (pup.ImageFile != null) {

                    //Spara bilder till wwwroot
                    string fileName = Path.GetFileNameWithoutExtension(pup.ImageFile.FileName);
                    string extension = Path.GetExtension(pup.ImageFile.FileName);

                    //Plockar bort mellanslag i filnam + lägger till timestamp
                    pup.ImageName = fileName = fileName.Replace(" ", String.Empty) + DateTime.Now.ToString("yymmssfff") + extension;

                    string path = Path.Combine(wwwRootPath + "/imageupload", fileName);

                    //Lagra Fil
                    using (var fileStream = new FileStream(path, FileMode.Create)) 
                    {
                        await pup.ImageFile.CopyToAsync(fileStream);
                    }

                     createImageFile(fileName);

                }
                else {
                    pup.ImageName = null;
                }



                _context.Add(pup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pup);
        }

        // GET: Pup/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pup == null)
            {
                return NotFound();
            }

            var pup = await _context.Pup.FindAsync(id);
            if (pup == null)
            {
                return NotFound();
            }
            return View(pup);
        }

        // POST: Pup/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Gender,Booked,ImageName")] Pup pup)
        {
            if (id != pup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PupExists(pup.Id))
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
            return View(pup);
        }

        // GET: Pup/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pup == null)
            {
                return NotFound();
            }

            var pup = await _context.Pup
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pup == null)
            {
                return NotFound();
            }

            return View(pup);
        }

        // POST: Pup/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pup == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Pup'  is null.");
            }
            var pup = await _context.Pup.FindAsync(id);

            
            if (pup != null)
            {
                _context.Pup.Remove(pup);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PupExists(int id)
        {
          return (_context.Pup?.Any(e => e.Id == id)).GetValueOrDefault();
        }


                //Funktion för biler
         
         private void createImageFile(string filename) {

            using(var img = Image.FromFile(Path.Combine(wwwRootPath + "/imageupload/" , filename))) {
              
                img.Scale(ImageWidth, ImageHeigth).SaveAs(Path.Combine(wwwRootPath + "/imageupload" + filename));
            } 


         }
    }
}
