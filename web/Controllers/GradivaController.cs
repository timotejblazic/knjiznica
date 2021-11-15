using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using web.Data;
using web.Models;

namespace web.Controllers
{
    public class GradivaController : Controller
    {
        private readonly KnjiznicaContext _context;

        public GradivaController(KnjiznicaContext context)
        {
            _context = context;
        }

        // GET: Gradiva
        public async Task<IActionResult> Index()
        {
            return View(await _context.Gradiva.ToListAsync());
        }

        // GET: Gradiva/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gradivo = await _context.Gradiva
                .FirstOrDefaultAsync(m => m.GradivoID == id);
            if (gradivo == null)
            {
                return NotFound();
            }

            return View(gradivo);
        }

        // GET: Gradiva/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gradiva/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GradivoID,Naslov,LetoIzdaje,SteviloStrani,Opis")] Gradivo gradivo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gradivo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gradivo);
        }

        // GET: Gradiva/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gradivo = await _context.Gradiva.FindAsync(id);
            if (gradivo == null)
            {
                return NotFound();
            }
            return View(gradivo);
        }

        // POST: Gradiva/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GradivoID,Naslov,LetoIzdaje,SteviloStrani,Opis")] Gradivo gradivo)
        {
            if (id != gradivo.GradivoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gradivo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GradivoExists(gradivo.GradivoID))
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
            return View(gradivo);
        }

        // GET: Gradiva/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gradivo = await _context.Gradiva
                .FirstOrDefaultAsync(m => m.GradivoID == id);
            if (gradivo == null)
            {
                return NotFound();
            }

            return View(gradivo);
        }

        // POST: Gradiva/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gradivo = await _context.Gradiva.FindAsync(id);
            _context.Gradiva.Remove(gradivo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GradivoExists(int id)
        {
            return _context.Gradiva.Any(e => e.GradivoID == id);
        }
    }
}
