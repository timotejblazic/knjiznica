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
    public class GradivoIzvodiController : Controller
    {
        private readonly KnjiznicaContext _context;

        public GradivoIzvodiController(KnjiznicaContext context)
        {
            _context = context;
        }

        // GET: GradivoIzvodi
        public async Task<IActionResult> Index()
        {
            return View(await _context.GradivoIzvodi.ToListAsync());
        }

        // GET: GradivoIzvodi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gradivoIzvod = await _context.GradivoIzvodi
                .FirstOrDefaultAsync(m => m.GradivoIzvodID == id);
            if (gradivoIzvod == null)
            {
                return NotFound();
            }

            return View(gradivoIzvod);
        }

        // GET: GradivoIzvodi/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GradivoIzvodi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GradivoIzvodID")] GradivoIzvod gradivoIzvod)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gradivoIzvod);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gradivoIzvod);
        }

        // GET: GradivoIzvodi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gradivoIzvod = await _context.GradivoIzvodi.FindAsync(id);
            if (gradivoIzvod == null)
            {
                return NotFound();
            }
            return View(gradivoIzvod);
        }

        // POST: GradivoIzvodi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GradivoIzvodID")] GradivoIzvod gradivoIzvod)
        {
            if (id != gradivoIzvod.GradivoIzvodID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gradivoIzvod);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GradivoIzvodExists(gradivoIzvod.GradivoIzvodID))
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
            return View(gradivoIzvod);
        }

        // GET: GradivoIzvodi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gradivoIzvod = await _context.GradivoIzvodi
                .FirstOrDefaultAsync(m => m.GradivoIzvodID == id);
            if (gradivoIzvod == null)
            {
                return NotFound();
            }

            return View(gradivoIzvod);
        }

        // POST: GradivoIzvodi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gradivoIzvod = await _context.GradivoIzvodi.FindAsync(id);
            _context.GradivoIzvodi.Remove(gradivoIzvod);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GradivoIzvodExists(int id)
        {
            return _context.GradivoIzvodi.Any(e => e.GradivoIzvodID == id);
        }
    }
}
