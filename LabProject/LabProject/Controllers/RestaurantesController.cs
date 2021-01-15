using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LabProject.Data;
using LabProject.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace LabProject.Controllers
{
    public class RestaurantesController : Controller
    {
        private readonly LabProject_Context _context;
        private IWebHostEnvironment _he;

        public RestaurantesController(LabProject_Context context, IWebHostEnvironment e)
        {
            _context = context;
            _he = e;
        }

        // GET: Restaurantes
        public async Task<IActionResult> Index()
        {
            var labProject_Context = _context.Restaurantes.Include(r => r.Utilizador);
            return View(await labProject_Context.ToListAsync());
        }



        public async Task<IActionResult> ListarRestaurantesPro()
        {
            var labProject_Context = _context.Restaurantes.Include(r => r.Utilizador).Where(r => r.Aprovado == false);
            return View(await labProject_Context.ToListAsync());

        }



        [HttpGet]
        public async Task<IActionResult> SetAprovado(int id, bool aprovado)
        {
            Restaurante _restaurante = _context.Restaurantes.Where(r => r.UtilizadorId == id).FirstOrDefault();

            if (aprovado)
            {

                _restaurante.Aprovado = true;
                _context.Update(_restaurante);
                await _context.SaveChangesAsync();

            }
            else
            {
                _context.Restaurantes.Remove(_restaurante);
                await _context.SaveChangesAsync();
                Utilizador _utilizador = _context.Utilizadors.Where(r => r.Id == id).FirstOrDefault();
                _context.Utilizadors.Remove(_utilizador);
                await _context.SaveChangesAsync();
            }


            return RedirectToAction("ListarRestaurantesPro", "Restaurantes");
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

        public async Task<IActionResult> VerRestaurante(int? id, string searchString, DateTime SearchData)
        {

            ViewData["CurrentFilter"] = searchString;

            if (SearchData == DateTime.MinValue)
                SearchData = DateTime.Now.Date;

            ViewData["SearchData"] = SearchData.ToString("MM-dd-yyyy");

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
                                                  where restaurantePrato.RestauranteId == Restaurante.Restaurante.Id && restaurantePrato.Dia == SearchData
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

            Restaurante.Pratos = Pratos.ToList();

            if (!String.IsNullOrEmpty(searchString))
            {
                Restaurante.Pratos = Pratos.Where(s => s.Nome.ToUpper().Contains(searchString.ToUpper()) || s.TipoPrato.Nome.ToUpper().Contains(searchString.ToUpper())).ToList();
            }



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


        public async Task<IActionResult> EditRes()
        {
            int id = Convert.ToInt32(HttpContext.Session.GetString("Id"));


            if (id == null)
            {
                return NotFound();
            }

            var restaurantes = await _context.Restaurantes.ToListAsync();
            var restaurante = restaurantes.First(f => f.UtilizadorId == id);
            if (restaurante == null)
            {
                return NotFound();
            }
            var utilizador = await _context.Utilizadors.FindAsync(restaurante.UtilizadorId);

            var Restaurante = new RestauranteCompleto();
            Restaurante.RestauranteCompletoSet(restaurante, utilizador);

            return View(Restaurante);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditRes([Bind("Id", "UtilizadorId", "Name", "Email", "Username", "Password", "Telefone", "Morada", "HoraAbertura", "HoraFecho", "DiaDescanso")] RestauranteCompleto restaurante, IFormFile files)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    try
                    {
                        if (files != null)
                        {
                            Random numAleatorio = new Random();
                            int valorInteiro = numAleatorio.Next(100, 1000);
                            string NomeFicheiro = HttpContext.Session.GetString("Id") + valorInteiro + Path.GetFileName(files.FileName);

                            string uploads = Path.Combine(_he.ContentRootPath, "wwwroot/Images/Utilizadores/", NomeFicheiro);

                            FileStream fs = new FileStream(uploads, FileMode.Create);

                            files.CopyTo(fs);
                            fs.Close();

                            restaurante.Imagem = Path.GetFileName(files.FileName); // opiniao dar id + nome da imagem pq as imagens podem ter nomes iguais
                            HttpContext.Session.SetString("Imagem", restaurante.Imagem);
                        }

                    }
                    catch (Exception)
                    {


                    }
                    restaurante.Imagem = HttpContext.Session.GetString("Imagem");
                    _context.Update(restaurante.GetRestaurante());
                    await _context.SaveChangesAsync();
                    _context.Update(restaurante.GetUtilizador());
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
                return RedirectToAction("Index", "Home");
            }
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
