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
    public class AdministrationsController : Controller
    {
        private readonly ufrSetContext _context;

        public AdministrationsController(ufrSetContext context)
        {
            _context = context;
        }

        // GET: Administrations
        public async Task<IActionResult> Index()
        {
              return View(await _context.Administration.ToListAsync());
        }

        // GET: Administrations/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Administration == null)
            {
                return NotFound();
            }

            var administration = await _context.Administration
                .FirstOrDefaultAsync(m => m.matricule == id);
            if (administration == null)
            {
                return NotFound();
            }

            return View(administration);
        }

        // GET: Administrations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Administrations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("matricule,Name,Email,Profession")] Administration administration)
        {
           // if (ModelState.IsValid)
           // {
                _context.Add(administration);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
           // }
            return View(administration);
        }

        // GET: Administrations/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Administration == null)
            {
                return NotFound();
            }

            var administration = await _context.Administration.FindAsync(id);
            if (administration == null)
            {
                return NotFound();
            }
            return View(administration);
        }

        // POST: Administrations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("matricule,Name,Email,Profession")] Administration administration)
        {
            if (id != administration.matricule)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(administration);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdministrationExists(administration.matricule))
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
            return View(administration);
        }

        // GET: Administrations/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Administration == null)
            {
                return NotFound();
            }

            var administration = await _context.Administration
                .FirstOrDefaultAsync(m => m.matricule == id);
            if (administration == null)
            {
                return NotFound();
            }

            return View(administration);
        }

        // POST: Administrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Administration == null)
            {
                return Problem("Entity set 'ufrSetContext.Administration'  is null.");
            }
            var administration = await _context.Administration.FindAsync(id);
            if (administration != null)
            {
                _context.Administration.Remove(administration);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdministrationExists(string id)
        {
          return _context.Administration.Any(e => e.matricule == id);
        }
    }
}
