using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LabProject.Data;
using LabProject.Models;

namespace LabProject.Controllers
{
    public class TipoPratoController : Controller
    {
        private readonly LabProject_Database _context;

        public TipoPratoController(LabProject_Database context)
        {
            _context = context;
        }

        // GET: TipoPratoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoPratos.ToListAsync());
        }

        // GET: TipoPratoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoPrato = await _context.TipoPratos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoPrato == null)
            {
                return NotFound();
            }

            return View(tipoPrato);
        }

        // GET: TipoPratoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoPratoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] TipoPrato tipoPrato)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoPrato);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoPrato);
        }

        // GET: TipoPratoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoPrato = await _context.TipoPratos.FindAsync(id);
            if (tipoPrato == null)
            {
                return NotFound();
            }
            return View(tipoPrato);
        }

        // POST: TipoPratoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] TipoPrato tipoPrato)
        {
            if (id != tipoPrato.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoPrato);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoPratoExists(tipoPrato.Id))
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
            return View(tipoPrato);
        }

        // GET: TipoPratoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoPrato = await _context.TipoPratos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoPrato == null)
            {
                return NotFound();
            }

            return View(tipoPrato);
        }

        // POST: TipoPratoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoPrato = await _context.TipoPratos.FindAsync(id);
            _context.TipoPratos.Remove(tipoPrato);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoPratoExists(int id)
        {
            return _context.TipoPratos.Any(e => e.Id == id);
        }
    }
}
