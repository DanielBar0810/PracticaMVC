using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PracticaMVC.Models;

namespace PracticaMVC.Controllers
{
    public class facultadesController : Controller
    {
        private readonly equiposDbContext _context;

        public facultadesController(equiposDbContext context)
        {
            _context = context;
        }

        // GET: facultades
        public async Task<IActionResult> Index()
        {
              return _context.facultades != null ? 
                          View(await _context.facultades.ToListAsync()) :
                          Problem("Entity set 'equiposDbContext.facultades'  is null.");
        }

        // GET: facultades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.facultades == null)
            {
                return NotFound();
            }

            var facultades = await _context.facultades
                .FirstOrDefaultAsync(m => m.facultad_id == id);
            if (facultades == null)
            {
                return NotFound();
            }

            return View(facultades);
        }

        // GET: facultades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: facultades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("facultad_id,nombre_facultad")] facultades facultades)
        {
            if (ModelState.IsValid)
            {
                _context.Add(facultades);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(facultades);
        }

        // GET: facultades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.facultades == null)
            {
                return NotFound();
            }

            var facultades = await _context.facultades.FindAsync(id);
            if (facultades == null)
            {
                return NotFound();
            }
            return View(facultades);
        }

        // POST: facultades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("facultad_id,nombre_facultad")] facultades facultades)
        {
            if (id != facultades.facultad_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(facultades);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!facultadesExists(facultades.facultad_id))
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
            return View(facultades);
        }

        // GET: facultades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.facultades == null)
            {
                return NotFound();
            }

            var facultades = await _context.facultades
                .FirstOrDefaultAsync(m => m.facultad_id == id);
            if (facultades == null)
            {
                return NotFound();
            }

            return View(facultades);
        }

        // POST: facultades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.facultades == null)
            {
                return Problem("Entity set 'equiposDbContext.facultades'  is null.");
            }
            var facultades = await _context.facultades.FindAsync(id);
            if (facultades != null)
            {
                _context.facultades.Remove(facultades);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool facultadesExists(int id)
        {
          return (_context.facultades?.Any(e => e.facultad_id == id)).GetValueOrDefault();
        }
    }
}
