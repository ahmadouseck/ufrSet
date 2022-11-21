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
    public class UfrsController : Controller
    {
        private readonly ufrSetContext _context;

        public UfrsController(ufrSetContext context)
        {
            _context = context;
        }

        // GET: Ufrs
        public async Task<IActionResult> Index()
        {
              return View(await _context.Ufr.ToListAsync());
        }

        // GET: Ufrs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ufr == null)
            {
                return NotFound();
            }

            var ufr = await _context.Ufr
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ufr == null)
            {
                return NotFound();
            }

            return View(ufr);
        }

        // GET: Ufrs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ufrs/Create
       
        [HttpPost]
  
        public async Task<IActionResult> Create( Ufr ufr)
        {
            //if (ModelState.IsValid)
           // {
                _context.Ufr.Add(ufr);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
              
           // }
            Console.WriteLine("DOXannnnnnnnnn");
            return View(ufr);
        }

        // GET: Ufrs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ufr == null)
            {
                return NotFound();
            }

            var ufr = await _context.Ufr.FindAsync(id);
            if (ufr == null)
            {
                return NotFound();
            }
            return View(ufr);
        }

        // POST: Ufrs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Ufr ufr)
        {
            if (id != ufr.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ufr);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UfrExists(ufr.Id))
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
            return View(ufr);
        }

        // GET: Ufrs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ufr == null)
            {
                return NotFound();
            }

            var ufr = await _context.Ufr
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ufr == null)
            {
                return NotFound();
            }

            return View(ufr);
        }

        // POST: Ufrs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ufr == null)
            {
                return Problem("Entity set 'ufrSetContext.Ufr'  is null.");
            }
            var ufr = await _context.Ufr.FindAsync(id);
            if (ufr != null)
            {
                _context.Ufr.Remove(ufr);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UfrExists(int id)
        {
          return _context.Ufr.Any(e => e.Id == id);
        }
    }
}
