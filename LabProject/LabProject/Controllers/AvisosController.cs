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
    public class AvisosController : Controller
    {
        private readonly LabProject_Database _context;

        public AvisosController(LabProject_Database context)
        {
            _context = context;
        }

        // GET: Avisos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Avisos.ToListAsync());
        }

        // GET: Avisos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aviso = await _context.Avisos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aviso == null)
            {
                return NotFound();
            }

            return View(aviso);
        }

        // GET: Avisos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Avisos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Descricao,Foto,Data")] Aviso aviso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aviso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aviso);
        }

        // GET: Avisos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aviso = await _context.Avisos.FindAsync(id);
            if (aviso == null)
            {
                return NotFound();
            }
            return View(aviso);
        }

        // POST: Avisos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Descricao,Foto,Data")] Aviso aviso)
        {
            if (id != aviso.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aviso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AvisoExists(aviso.Id))
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
            return View(aviso);
        }

        // GET: Avisos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aviso = await _context.Avisos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aviso == null)
            {
                return NotFound();
            }

            return View(aviso);
        }

        // POST: Avisos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aviso = await _context.Avisos.FindAsync(id);
            _context.Avisos.Remove(aviso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AvisoExists(int id)
        {
            return _context.Avisos.Any(e => e.Id == id);
        }
    }
}
