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
    public class RestaurantesController : Controller
    {
        private readonly LabProject_Context _context;

        public RestaurantesController(LabProject_Context context)
        {
            _context = context;
        }

        // GET: Restaurantes
        public async Task<IActionResult> Index()
        {
            var labProject_Context = _context.Restaurantes.Include(r => r.Utilizador);
            return View(await labProject_Context.ToListAsync());
        }

        // GET: Restaurantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurante = await _context.Restaurantes
                .Include(r => r.Utilizador)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (restaurante == null)
            {
                return NotFound();
            }

            return View(restaurante);
        }

        public async Task<IActionResult> VerRestaurante(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            RestaurantePratosPertence Restaurante = new RestaurantePratosPertence();

            Restaurante.Restaurante = await _context.Restaurantes
                .Include(r => r.Utilizador)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Restaurante.Restaurante == null)
            {
                return NotFound();
            }



            //var _p = await (from Prato in _context.Pratos
            //                            join restaurantePrato in _context.RestaurantePratos on Prato.Id equals restaurantePrato.PratoId
            //                            where restaurantePrato.RestauranteId == Restaurante.Restaurante.Id
            //                            select Prato).Include(p => p.TipoPrato).ToListAsync();

            List<PratoIndividual> Pratos = await (from prato in _context.Pratos
                                                  join restaurantePrato in _context.RestaurantePratos on prato.Id equals restaurantePrato.PratoId
                                                  where restaurantePrato.RestauranteId == Restaurante.Restaurante.Id
                                                  select new PratoIndividual
                                                  {
                                                      Id = prato.Id,
                                                      Nome = prato.Nome,
                                                      Preco = restaurantePrato.Preco,
                                                      TipoPratoId = prato.TipoPratoId,
                                                      TipoPrato = prato.TipoPrato,
                                                      RestaurantePratos = prato.RestaurantePratos,
                                                      Descricao = restaurantePrato.Descricao,
                                                      Foto = restaurantePrato.Foto,
                                                  }).ToListAsync();

            Restaurante.Pratos = Pratos;

            //var ContextRP = _context.RestaurantePratos;

            //foreach (var p in _p)
            //{
            //    try
            //    {
            //        Restaurante.Pratos.Add(new PratoIndividual(p, (from RestaurantePrato in ContextRP
            //                                                       where RestaurantePrato.PratoId == p.Id && RestaurantePrato.RestauranteId == Restaurante.Restaurante.Id
            //                                                       select RestaurantePrato.Preco).ToList()[0], (from RestaurantePrato in ContextRP
            //                                                                                                    where RestaurantePrato.PratoId == p.Id && RestaurantePrato.RestauranteId == Restaurante.Restaurante.Id
            //                                                                                                    select RestaurantePrato.Descricao).ToList()[0], (from RestaurantePrato in ContextRP
            //                                                                                                                                                     where RestaurantePrato.PratoId == p.Id && RestaurantePrato.RestauranteId == Restaurante.Restaurante.Id
            //                                                                                                                                                     select RestaurantePrato.Foto).ToList()[0]));



            //    }
            //    catch {
            //        Restaurante.Pratos.Add(new PratoIndividual(p, 0, "", ""))  ;
            //    }
        //}
            
            

            return View(Restaurante);
    }

    // GET: Restaurantes/Create
    public IActionResult Create()
    {
        ViewData["UtilizadorId"] = new SelectList(_context.Utilizadors, "Id", "Email");
        return View();
    }

    // POST: Restaurantes/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,UtilizadorId,Telefone,Morada,HoraAbertura,HoraFecho,DiaDescanso,Aprovado")] Restaurante restaurante)
    {
        if (ModelState.IsValid)
        {
            _context.Add(restaurante);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["UtilizadorId"] = new SelectList(_context.Utilizadors, "Id", "Email", restaurante.UtilizadorId);
        return View(restaurante);
    }

    // GET: Restaurantes/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var restaurante = await _context.Restaurantes.FindAsync(id);
        if (restaurante == null)
        {
            return NotFound();
        }
        ViewData["UtilizadorId"] = new SelectList(_context.Utilizadors, "Id", "Email", restaurante.UtilizadorId);
        return View(restaurante);
    }

    // POST: Restaurantes/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,UtilizadorId,Telefone,Morada,HoraAbertura,HoraFecho,DiaDescanso,Aprovado")] Restaurante restaurante)
    {
        if (id != restaurante.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(restaurante);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestauranteExists(restaurante.Id))
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
        ViewData["UtilizadorId"] = new SelectList(_context.Utilizadors, "Id", "Email", restaurante.UtilizadorId);
        return View(restaurante);
    }

    // GET: Restaurantes/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var restaurante = await _context.Restaurantes
            .Include(r => r.Utilizador)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (restaurante == null)
        {
            return NotFound();
        }

        return View(restaurante);
    }

    // POST: Restaurantes/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var restaurante = await _context.Restaurantes.FindAsync(id);
        _context.Restaurantes.Remove(restaurante);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool RestauranteExists(int id)
    {
        return _context.Restaurantes.Any(e => e.Id == id);
    }
}
}
