using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ufrSet.Data;
using ufrSet.Models;

namespace ufrSet.Controllers
{
    public class FilieresController : Controller
    {
        private readonly ufrSetContext _context;

        public FilieresController(ufrSetContext context)
        {
            _context = context;
        }

        // GET: Filieres
        public async Task<IActionResult> Index()
        {
              return View(await _context.Filiere.ToListAsync());
        }

        // GET: Filieres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Filiere == null)
            {
                return NotFound();
            }

            var filiere = await _context.Filiere
                .FirstOrDefaultAsync(m => m.Id == id);
            if (filiere == null)
            {
                return NotFound();
            }

            return View(filiere);
        }

        // GET: Filieres/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Filieres/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Filiere filiere)
        {
           // if (ModelState.IsValid)
           // {
                _context.Add(filiere);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
           // }
            return View(filiere);
        }

        // GET: Filieres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Filiere == null)
            {
                return NotFound();
            }

            var filiere = await _context.Filiere.FindAsync(id);
            if (filiere == null)
            {
                return NotFound();
            }
            return View(filiere);
        }

        // POST: Filieres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Filiere filiere)
        {
            if (id != filiere.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filiere);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FiliereExists(filiere.Id))
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
            return View(filiere);
        }

        // GET: Filieres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Filiere == null)
            {
                return NotFound();
            }

            var filiere = await _context.Filiere
                .FirstOrDefaultAsync(m => m.Id == id);
            if (filiere == null)
            {
                return NotFound();
            }

            return View(filiere);
        }

        // POST: Filieres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Filiere == null)
            {
                return Problem("Entity set 'ufrSetContext.Filiere'  is null.");
            }
            var filiere = await _context.Filiere.FindAsync(id);
            if (filiere != null)
            {
                _context.Filiere.Remove(filiere);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FiliereExists(int id)
        {
          return _context.Filiere.Any(e => e.Id == id);
        }
    }
}
