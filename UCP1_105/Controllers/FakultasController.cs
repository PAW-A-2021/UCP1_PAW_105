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
    public class FakultasController : Controller
    {
        private readonly PendataanContext _context;

        public FakultasController(PendataanContext context)
        {
            _context = context;
        }

        // GET: Fakultas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Fakultas.ToListAsync());
        }

        // GET: Fakultas/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fakultas = await _context.Fakultas
                .FirstOrDefaultAsync(m => m.IdFakultas == id);
            if (fakultas == null)
            {
                return NotFound();
            }

            return View(fakultas);
        }

        // GET: Fakultas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fakultas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFakultas,NamaFakultas")] Fakultas fakultas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fakultas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fakultas);
        }

        // GET: Fakultas/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fakultas = await _context.Fakultas.FindAsync(id);
            if (fakultas == null)
            {
                return NotFound();
            }
            return View(fakultas);
        }

        // POST: Fakultas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdFakultas,NamaFakultas")] Fakultas fakultas)
        {
            if (id != fakultas.IdFakultas)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fakultas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FakultasExists(fakultas.IdFakultas))
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
            return View(fakultas);
        }

        // GET: Fakultas/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fakultas = await _context.Fakultas
                .FirstOrDefaultAsync(m => m.IdFakultas == id);
            if (fakultas == null)
            {
                return NotFound();
            }

            return View(fakultas);
        }

        // POST: Fakultas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var fakultas = await _context.Fakultas.FindAsync(id);
            _context.Fakultas.Remove(fakultas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FakultasExists(string id)
        {
            return _context.Fakultas.Any(e => e.IdFakultas == id);
        }
    }
}
