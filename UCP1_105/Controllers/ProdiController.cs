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
    public class ProdiController : Controller
    {
        private readonly PendataanContext _context;

        public ProdiController(PendataanContext context)
        {
            _context = context;
        }

        // GET: Prodi
        public async Task<IActionResult> Index()
        {
            var pendataanContext = _context.Prodi.Include(p => p.IdMatkulNavigation);
            return View(await pendataanContext.ToListAsync());
        }

        // GET: Prodi/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prodi = await _context.Prodi
                .Include(p => p.IdMatkulNavigation)
                .FirstOrDefaultAsync(m => m.IdProdi == id);
            if (prodi == null)
            {
                return NotFound();
            }

            return View(prodi);
        }

        // GET: Prodi/Create
        public IActionResult Create()
        {
            ViewData["IdMatkul"] = new SelectList(_context.MataKuliah, "IdMatkul", "IdMatkul");
            return View();
        }

        // POST: Prodi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProdi,NamaProdi,IdMatkul")] Prodi prodi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prodi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdMatkul"] = new SelectList(_context.MataKuliah, "IdMatkul", "IdMatkul", prodi.IdMatkul);
            return View(prodi);
        }

        // GET: Prodi/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prodi = await _context.Prodi.FindAsync(id);
            if (prodi == null)
            {
                return NotFound();
            }
            ViewData["IdMatkul"] = new SelectList(_context.MataKuliah, "IdMatkul", "IdMatkul", prodi.IdMatkul);
            return View(prodi);
        }

        // POST: Prodi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdProdi,NamaProdi,IdMatkul")] Prodi prodi)
        {
            if (id != prodi.IdProdi)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prodi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdiExists(prodi.IdProdi))
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
            ViewData["IdMatkul"] = new SelectList(_context.MataKuliah, "IdMatkul", "IdMatkul", prodi.IdMatkul);
            return View(prodi);
        }

        // GET: Prodi/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prodi = await _context.Prodi
                .Include(p => p.IdMatkulNavigation)
                .FirstOrDefaultAsync(m => m.IdProdi == id);
            if (prodi == null)
            {
                return NotFound();
            }

            return View(prodi);
        }

        // POST: Prodi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var prodi = await _context.Prodi.FindAsync(id);
            _context.Prodi.Remove(prodi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdiExists(string id)
        {
            return _context.Prodi.Any(e => e.IdProdi == id);
        }
    }
}
