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
    public class PersController : Controller
    {
        private readonly ufrSetContext _context;

        public PersController(ufrSetContext context)
        {
            _context = context;
        }

        // GET: Pers
        public async Task<IActionResult> Index()
        {
              return View(await _context.Pers.ToListAsync());
        }

        // GET: Pers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Pers == null)
            {
                return NotFound();
            }

            var pers = await _context.Pers
                .FirstOrDefaultAsync(m => m.matricule == id);
            if (pers == null)
            {
                return NotFound();
            }

            return View(pers);
        }

        // GET: Pers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("matricule,Name,Email,profession")] Pers pers)
        {
           // if (ModelState.IsValid)
            //{
                _context.Add(pers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            //}
            return View(pers);
        }

        // GET: Pers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Pers == null)
            {
                return NotFound();
            }

            var pers = await _context.Pers.FindAsync(id);
            if (pers == null)
            {
                return NotFound();
            }
            return View(pers);
        }

        // POST: Pers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("matricule,Name,Email,profession")] Pers pers)
        {
            if (id != pers.matricule)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersExists(pers.matricule))
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
            return View(pers);
        }

        // GET: Pers/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Pers == null)
            {
                return NotFound();
            }

            var pers = await _context.Pers
                .FirstOrDefaultAsync(m => m.matricule == id);
            if (pers == null)
            {
                return NotFound();
            }

            return View(pers);
        }

        // POST: Pers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Pers == null)
            {
                return Problem("Entity set 'ufrSetContext.Pers'  is null.");
            }
            var pers = await _context.Pers.FindAsync(id);
            if (pers != null)
            {
                _context.Pers.Remove(pers);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersExists(string id)
        {
          return _context.Pers.Any(e => e.matricule == id);
        }
    }
}
