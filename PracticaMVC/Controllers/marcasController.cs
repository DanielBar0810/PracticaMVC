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
    public class marcasController : Controller
    {
        private readonly equiposDbContext _context;

        public marcasController(equiposDbContext context)
        {
            _context = context;
        }

        // GET: marcas
        public async Task<IActionResult> Index()
        {
              return _context.marcas != null ? 
                          View(await _context.marcas.ToListAsync()) :
                          Problem("Entity set 'equiposDbContext.marcas'  is null.");
        }

        // GET: marcas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.marcas == null)
            {
                return NotFound();
            }

            var marcas = await _context.marcas
                .FirstOrDefaultAsync(m => m.id_marcas == id);
            if (marcas == null)
            {
                return NotFound();
            }

            return View(marcas);
        }

        // GET: marcas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: marcas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_marcas,nombre_marca,estados")] marcas marcas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(marcas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(marcas);
        }

        // GET: marcas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.marcas == null)
            {
                return NotFound();
            }

            var marcas = await _context.marcas.FindAsync(id);
            if (marcas == null)
            {
                return NotFound();
            }
            return View(marcas);
        }

        // POST: marcas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_marcas,nombre_marca,estados")] marcas marcas)
        {
            if (id != marcas.id_marcas)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(marcas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!marcasExists(marcas.id_marcas))
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
            return View(marcas);
        }

        // GET: marcas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.marcas == null)
            {
                return NotFound();
            }

            var marcas = await _context.marcas
                .FirstOrDefaultAsync(m => m.id_marcas == id);
            if (marcas == null)
            {
                return NotFound();
            }

            return View(marcas);
        }

        // POST: marcas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.marcas == null)
            {
                return Problem("Entity set 'equiposDbContext.marcas'  is null.");
            }
            var marcas = await _context.marcas.FindAsync(id);
            if (marcas != null)
            {
                _context.marcas.Remove(marcas);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool marcasExists(int id)
        {
          return (_context.marcas?.Any(e => e.id_marcas == id)).GetValueOrDefault();
        }
    }
}
