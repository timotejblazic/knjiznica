using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using web.Data;
using web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace web.Controllers
{
    [Authorize]
    public class NakupiController : Controller
    {
        private readonly KnjiznicaContext _context;
        private readonly UserManager<Uporabnik> _usermanager;

        public NakupiController(KnjiznicaContext context, UserManager<Uporabnik> userManager)
        {
            _context = context;
            _usermanager = userManager;
        }

        // GET: Nakupi
        [Authorize(Roles = "Administrator,Moderator")]
        public async Task<IActionResult> Index()
        {
            var knjiznicaContext = _context.Nakupi.Include(n => n.Uporabnik);
            return View(await knjiznicaContext.ToListAsync());
        }

        // GET: Nakupi/Details/5
        [Authorize(Roles = "Administrator,Moderator")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nakup = await _context.Nakupi
                .Include(n => n.Uporabnik)
                .FirstOrDefaultAsync(m => m.NakupID == id);
            if (nakup == null)
            {
                return NotFound();
            }

            return View(nakup);
        }

        // GET: Nakupi/Create
        public IActionResult Create(int? idGradivoIzvod)
        {
            TempData["idGI"] = idGradivoIzvod;
            return View();
        }

        // POST: Nakupi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NakupID,DatumNakupa,Cena,UporabnikID,IdKupljenegaGradiva")] Nakup nakup)
        {
            var currentUser = await _usermanager.GetUserAsync(User);

            if (ModelState.IsValid)
            {
                nakup.DatumNakupa = DateTime.Now;
                nakup.Cena = 10.15m;
                nakup.UporabnikID = currentUser.Id;
                nakup.IdKupljenegaGradiva = (int)TempData["idGI"];
                _context.Add(nakup);
                await _context.SaveChangesAsync();
                return RedirectToAction("NakupIDZapisiVGradivoIzvod", "GradivoIzvodi", new { idGradivoIzvod = (int)TempData["idGI"], idNakup = nakup.NakupID });
            }
            return View(nakup);
        }

        // GET: Nakupi/Edit/5
        [Authorize(Roles = "Administrator,Moderator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nakup = await _context.Nakupi.FindAsync(id);
            if (nakup == null)
            {
                return NotFound();
            }
            ViewData["UporabnikID"] = new SelectList(_context.Uporabniki, "Id", "Id", nakup.UporabnikID);
            return View(nakup);
        }

        // POST: Nakupi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrator,Moderator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NakupID,DatumNakupa,Cena,UporabnikID")] Nakup nakup)
        {
            if (id != nakup.NakupID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nakup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NakupExists(nakup.NakupID))
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
            ViewData["UporabnikID"] = new SelectList(_context.Uporabniki, "Id", "Id", nakup.UporabnikID);
            return View(nakup);
        }

        // GET: Nakupi/Delete/5
        [Authorize(Roles = "Administrator,Moderator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nakup = await _context.Nakupi
                .Include(n => n.Uporabnik)
                .FirstOrDefaultAsync(m => m.NakupID == id);
            if (nakup == null)
            {
                return NotFound();
            }

            return View(nakup);
        }

        // POST: Nakupi/Delete/5
        [Authorize(Roles = "Administrator,Moderator")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nakup = await _context.Nakupi.FindAsync(id);
            _context.Nakupi.Remove(nakup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NakupExists(int id)
        {
            return _context.Nakupi.Any(e => e.NakupID == id);
        }
    }
}
