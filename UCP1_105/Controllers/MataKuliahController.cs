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
    public class MataKuliahController : Controller
    {
        private readonly PendataanContext _context;

        public MataKuliahController(PendataanContext context)
        {
            _context = context;
        }

        // GET: MataKuliah
        public async Task<IActionResult> Index()
        {
            return View(await _context.MataKuliah.ToListAsync());
        }

        // GET: MataKuliah/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mataKuliah = await _context.MataKuliah
                .FirstOrDefaultAsync(m => m.IdMatkul == id);
            if (mataKuliah == null)
            {
                return NotFound();
            }

            return View(mataKuliah);
        }

        // GET: MataKuliah/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MataKuliah/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMatkul,NamaMatkul,KodeMatkul")] MataKuliah mataKuliah)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mataKuliah);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mataKuliah);
        }

        // GET: MataKuliah/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mataKuliah = await _context.MataKuliah.FindAsync(id);
            if (mataKuliah == null)
            {
                return NotFound();
            }
            return View(mataKuliah);
        }

        // POST: MataKuliah/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdMatkul,NamaMatkul,KodeMatkul")] MataKuliah mataKuliah)
        {
            if (id != mataKuliah.IdMatkul)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mataKuliah);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MataKuliahExists(mataKuliah.IdMatkul))
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
            return View(mataKuliah);
        }

        // GET: MataKuliah/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mataKuliah = await _context.MataKuliah
                .FirstOrDefaultAsync(m => m.IdMatkul == id);
            if (mataKuliah == null)
            {
                return NotFound();
            }

            return View(mataKuliah);
        }

        // POST: MataKuliah/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var mataKuliah = await _context.MataKuliah.FindAsync(id);
            _context.MataKuliah.Remove(mataKuliah);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MataKuliahExists(string id)
        {
            return _context.MataKuliah.Any(e => e.IdMatkul == id);
        }
    }
}
