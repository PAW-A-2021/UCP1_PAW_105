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
    public class MahasiswaController : Controller
    {
        private readonly PendataanContext _context;

        public MahasiswaController(PendataanContext context)
        {
            _context = context;
        }

        // GET: Mahasiswa
        public async Task<IActionResult> Index()
        {
            var pendataanContext = _context.Mahasiswa.Include(m => m.IdUnivNavigation);
            return View(await pendataanContext.ToListAsync());
        }

        // GET: Mahasiswa/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mahasiswa = await _context.Mahasiswa
                .Include(m => m.IdUnivNavigation)
                .FirstOrDefaultAsync(m => m.IdMahasiswa == id);
            if (mahasiswa == null)
            {
                return NotFound();
            }

            return View(mahasiswa);
        }

        // GET: Mahasiswa/Create
        public IActionResult Create()
        {
            ViewData["IdUniv"] = new SelectList(_context.Universitas, "IdUniv", "IdUniv");
            return View();
        }

        // POST: Mahasiswa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMahasiswa,NamaMahasiswa,NimMahasiswa,IdUniv")] Mahasiswa mahasiswa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mahasiswa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdUniv"] = new SelectList(_context.Universitas, "IdUniv", "IdUniv", mahasiswa.IdUniv);
            return View(mahasiswa);
        }

        // GET: Mahasiswa/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mahasiswa = await _context.Mahasiswa.FindAsync(id);
            if (mahasiswa == null)
            {
                return NotFound();
            }
            ViewData["IdUniv"] = new SelectList(_context.Universitas, "IdUniv", "IdUniv", mahasiswa.IdUniv);
            return View(mahasiswa);
        }

        // POST: Mahasiswa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdMahasiswa,NamaMahasiswa,NimMahasiswa,IdUniv")] Mahasiswa mahasiswa)
        {
            if (id != mahasiswa.IdMahasiswa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mahasiswa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MahasiswaExists(mahasiswa.IdMahasiswa))
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
            ViewData["IdUniv"] = new SelectList(_context.Universitas, "IdUniv", "IdUniv", mahasiswa.IdUniv);
            return View(mahasiswa);
        }

        // GET: Mahasiswa/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mahasiswa = await _context.Mahasiswa
                .Include(m => m.IdUnivNavigation)
                .FirstOrDefaultAsync(m => m.IdMahasiswa == id);
            if (mahasiswa == null)
            {
                return NotFound();
            }

            return View(mahasiswa);
        }

        // POST: Mahasiswa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var mahasiswa = await _context.Mahasiswa.FindAsync(id);
            _context.Mahasiswa.Remove(mahasiswa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MahasiswaExists(string id)
        {
            return _context.Mahasiswa.Any(e => e.IdMahasiswa == id);
        }
    }
}
