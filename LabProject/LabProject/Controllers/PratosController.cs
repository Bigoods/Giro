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
    public class PratosController : Controller
    {
        private readonly LabProject_Database _context;

        public PratosController(LabProject_Database context)
        {
            _context = context;
        }

        // GET: Pratos
        public async Task<IActionResult> Index()
        {
            var labProject_Database = _context.Pratos.Include(p => p.TipoPrato);
            
            return View(await labProject_Database.ToListAsync());
        }

        public string Truncate(string yourString, int maxLength)
        {
            // If the string isn't null or empty
            if (!String.IsNullOrEmpty(yourString))
            {
                // Return the appropriate string size
                return (yourString.Length <= maxLength) ? yourString : yourString.Substring(0, maxLength) + "...";
            }
            else
            {
                // Otherwise return the empty string
                return "";
            }
        }

        public async Task<IActionResult> Pratos()
        {
            var labProject_Database = _context.Pratos.Include(p => p.TipoPrato);
            foreach (Prato p in labProject_Database)
            {
                p.Nome = Truncate(p.Nome, 14);
            }
            return View(await labProject_Database.ToListAsync());
        }

        // GET: Pratos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prato = await _context.Pratos
                .Include(p => p.TipoPrato)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prato == null)
            {
                return NotFound();
            }

            return View(prato);
        }

        // GET: Pratos/Create
        public IActionResult Create()
        {
            ViewData["TipoPratoId"] = new SelectList(_context.TipoPratos, "Id", "Nome");
            return View();
        }

        // POST: Pratos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Preco,Descricao,TipoPratoId")] Prato prato)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prato);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoPratoId"] = new SelectList(_context.TipoPratos, "Id", "Nome", prato.TipoPratoId);
            return View(prato);
        }

        // GET: Pratos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prato = await _context.Pratos.FindAsync(id);
            if (prato == null)
            {
                return NotFound();
            }
            ViewData["TipoPratoId"] = new SelectList(_context.TipoPratos, "Id", "Nome", prato.TipoPratoId);
            return View(prato);
        }

        // POST: Pratos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Preco,Descricao,TipoPratoId")] Prato prato)
        {
            if (id != prato.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prato);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PratoExists(prato.Id))
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
            ViewData["TipoPratoId"] = new SelectList(_context.TipoPratos, "Id", "Nome", prato.TipoPratoId);
            return View(prato);
        }

        // GET: Pratos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prato = await _context.Pratos
                .Include(p => p.TipoPrato)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prato == null)
            {
                return NotFound();
            }

            return View(prato);
        }

        // POST: Pratos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prato = await _context.Pratos.FindAsync(id);
            _context.Pratos.Remove(prato);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PratoExists(int id)
        {
            return _context.Pratos.Any(e => e.Id == id);
        }
    }
}
