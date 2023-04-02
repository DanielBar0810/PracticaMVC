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
    public class estados_reservaController : Controller
    {
        private readonly equiposDbContext _context;

        public estados_reservaController(equiposDbContext context)
        {
            _context = context;
        }

        // GET: estados_reserva
        public async Task<IActionResult> Index()
        {
              return _context.estados_reserva != null ? 
                          View(await _context.estados_reserva.ToListAsync()) :
                          Problem("Entity set 'equiposDbContext.estados_reserva'  is null.");
        }

        // GET: estados_reserva/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.estados_reserva == null)
            {
                return NotFound();
            }

            var estados_reserva = await _context.estados_reserva
                .FirstOrDefaultAsync(m => m.estado_res_id == id);
            if (estados_reserva == null)
            {
                return NotFound();
            }

            return View(estados_reserva);
        }

        // GET: estados_reserva/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: estados_reserva/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("estado_res_id,estado")] estados_reserva estados_reserva)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estados_reserva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estados_reserva);
        }

        // GET: estados_reserva/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.estados_reserva == null)
            {
                return NotFound();
            }

            var estados_reserva = await _context.estados_reserva.FindAsync(id);
            if (estados_reserva == null)
            {
                return NotFound();
            }
            return View(estados_reserva);
        }

        // POST: estados_reserva/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("estado_res_id,estado")] estados_reserva estados_reserva)
        {
            if (id != estados_reserva.estado_res_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estados_reserva);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!estados_reservaExists(estados_reserva.estado_res_id))
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
            return View(estados_reserva);
        }

        // GET: estados_reserva/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.estados_reserva == null)
            {
                return NotFound();
            }

            var estados_reserva = await _context.estados_reserva
                .FirstOrDefaultAsync(m => m.estado_res_id == id);
            if (estados_reserva == null)
            {
                return NotFound();
            }

            return View(estados_reserva);
        }

        // POST: estados_reserva/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.estados_reserva == null)
            {
                return Problem("Entity set 'equiposDbContext.estados_reserva'  is null.");
            }
            var estados_reserva = await _context.estados_reserva.FindAsync(id);
            if (estados_reserva != null)
            {
                _context.estados_reserva.Remove(estados_reserva);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool estados_reservaExists(int id)
        {
          return (_context.estados_reserva?.Any(e => e.estado_res_id == id)).GetValueOrDefault();
        }
    }
}
