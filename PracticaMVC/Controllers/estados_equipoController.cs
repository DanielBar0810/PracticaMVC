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
    public class estados_equipoController : Controller
    {
        private readonly equiposDbContext _context;

        public estados_equipoController(equiposDbContext context)
        {
            _context = context;
        }

        // GET: estados_equipo
        public async Task<IActionResult> Index()
        {
              return _context.estados_equipo != null ? 
                          View(await _context.estados_equipo.ToListAsync()) :
                          Problem("Entity set 'equiposDbContext.estados_equipo'  is null.");
        }

        // GET: estados_equipo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.estados_equipo == null)
            {
                return NotFound();
            }

            var estados_equipo = await _context.estados_equipo
                .FirstOrDefaultAsync(m => m.id_estados_equipo == id);
            if (estados_equipo == null)
            {
                return NotFound();
            }

            return View(estados_equipo);
        }

        // GET: estados_equipo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: estados_equipo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_estados_equipo,descripcion,estado")] estados_equipo estados_equipo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estados_equipo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estados_equipo);
        }

        // GET: estados_equipo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.estados_equipo == null)
            {
                return NotFound();
            }

            var estados_equipo = await _context.estados_equipo.FindAsync(id);
            if (estados_equipo == null)
            {
                return NotFound();
            }
            return View(estados_equipo);
        }

        // POST: estados_equipo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_estados_equipo,descripcion,estado")] estados_equipo estados_equipo)
        {
            if (id != estados_equipo.id_estados_equipo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estados_equipo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!estados_equipoExists(estados_equipo.id_estados_equipo))
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
            return View(estados_equipo);
        }

        // GET: estados_equipo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.estados_equipo == null)
            {
                return NotFound();
            }

            var estados_equipo = await _context.estados_equipo
                .FirstOrDefaultAsync(m => m.id_estados_equipo == id);
            if (estados_equipo == null)
            {
                return NotFound();
            }

            return View(estados_equipo);
        }

        // POST: estados_equipo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.estados_equipo == null)
            {
                return Problem("Entity set 'equiposDbContext.estados_equipo'  is null.");
            }
            var estados_equipo = await _context.estados_equipo.FindAsync(id);
            if (estados_equipo != null)
            {
                _context.estados_equipo.Remove(estados_equipo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool estados_equipoExists(int id)
        {
          return (_context.estados_equipo?.Any(e => e.id_estados_equipo == id)).GetValueOrDefault();
        }
    }
}
