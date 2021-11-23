using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UCP1_105.Models;

namespace UCP1_105.Controllers
{
    public class UniversitasController : Controller
    {
        private readonly PendataanContext _context;

        public UniversitasController(PendataanContext context)
        {
            _context = context;
        }

        // GET: Universitas
        public async Task<IActionResult> Index()
        {
            var pendataanContext = _context.Universitas.Include(u => u.IdFakultasNavigation).Include(u => u.IdProdiNavigation);
            return View(await pendataanContext.ToListAsync());
        }

        // GET: Universitas/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var universitas = await _context.Universitas
                .Include(u => u.IdFakultasNavigation)
                .Include(u => u.IdProdiNavigation)
                .FirstOrDefaultAsync(m => m.IdUniv == id);
            if (universitas == null)
            {
                return NotFound();
            }

            return View(universitas);
        }

        // GET: Universitas/Create
        public IActionResult Create()
        {
            ViewData["IdFakultas"] = new SelectList(_context.Fakultas, "IdFakultas", "IdFakultas");
            ViewData["IdProdi"] = new SelectList(_context.Prodi, "IdProdi", "IdProdi");
            return View();
        }

        // POST: Universitas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUniv,NamaUniv,IdFakultas,IdProdi")] Universitas universitas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(universitas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdFakultas"] = new SelectList(_context.Fakultas, "IdFakultas", "IdFakultas", universitas.IdFakultas);
            ViewData["IdProdi"] = new SelectList(_context.Prodi, "IdProdi", "IdProdi", universitas.IdProdi);
            return View(universitas);
        }

        // GET: Universitas/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var universitas = await _context.Universitas.FindAsync(id);
            if (universitas == null)
            {
                return NotFound();
            }
            ViewData["IdFakultas"] = new SelectList(_context.Fakultas, "IdFakultas", "IdFakultas", universitas.IdFakultas);
            ViewData["IdProdi"] = new SelectList(_context.Prodi, "IdProdi", "IdProdi", universitas.IdProdi);
            return View(universitas);
        }

        // POST: Universitas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdUniv,NamaUniv,IdFakultas,IdProdi")] Universitas universitas)
        {
            if (id != universitas.IdUniv)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(universitas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UniversitasExists(universitas.IdUniv))
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
            ViewData["IdFakultas"] = new SelectList(_context.Fakultas, "IdFakultas", "IdFakultas", universitas.IdFakultas);
            ViewData["IdProdi"] = new SelectList(_context.Prodi, "IdProdi", "IdProdi", universitas.IdProdi);
            return View(universitas);
        }

        // GET: Universitas/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var universitas = await _context.Universitas
                .Include(u => u.IdFakultasNavigation)
                .Include(u => u.IdProdiNavigation)
                .FirstOrDefaultAsync(m => m.IdUniv == id);
            if (universitas == null)
            {
                return NotFound();
            }

            return View(universitas);
        }

        // POST: Universitas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var universitas = await _context.Universitas.FindAsync(id);
            _context.Universitas.Remove(universitas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UniversitasExists(string id)
        {
            return _context.Universitas.Any(e => e.IdUniv == id);
        }
    }
}
