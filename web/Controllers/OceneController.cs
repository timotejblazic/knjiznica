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
    public class OceneController : Controller
    {
        private readonly KnjiznicaContext _context;

        public OceneController(KnjiznicaContext context)
        {
            _context = context;
        }

        // GET: Ocene
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ocene.ToListAsync());
        }

        // GET: Ocene/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ocena = await _context.Ocene
                .FirstOrDefaultAsync(m => m.OcenaID == id);
            if (ocena == null)
            {
                return NotFound();
            }

            return View(ocena);
        }

        // GET: Ocene/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ocene/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OcenaID,Vrednost,Mnenje")] Ocena ocena)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ocena);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ocena);
        }

        // GET: Ocene/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ocena = await _context.Ocene.FindAsync(id);
            if (ocena == null)
            {
                return NotFound();
            }
            return View(ocena);
        }

        // POST: Ocene/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OcenaID,Vrednost,Mnenje")] Ocena ocena)
        {
            if (id != ocena.OcenaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ocena);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OcenaExists(ocena.OcenaID))
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
            return View(ocena);
        }

        // GET: Ocene/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ocena = await _context.Ocene
                .FirstOrDefaultAsync(m => m.OcenaID == id);
            if (ocena == null)
            {
                return NotFound();
            }

            return View(ocena);
        }

        // POST: Ocene/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ocena = await _context.Ocene.FindAsync(id);
            _context.Ocene.Remove(ocena);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OcenaExists(int id)
        {
            return _context.Ocene.Any(e => e.OcenaID == id);
        }
    }
}
