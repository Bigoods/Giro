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
        private readonly LabProject_Context _context;

        public PratosController(LabProject_Context context)
        {
            _context = context;
        }

        // GET: Pratos
        public async Task<IActionResult> Index()
        {
            var labProject_Database = _context.Pratos.Include(p => p.TipoPrato);

            //foreach(Prato p in labProject_Database)
            //{
            //    var Imagem = (from restaurantePratos in _context.RestaurantePratos
            //                     where (restaurantePratos.Id == p.Id)                                                  
            //                     select restaurantePratos.Foto).Take(1);


            //} 

            labProject_Database.Include(p => p.RestaurantePratos.Take(1));


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

        //public async Task<IActionResult> Pratos()
        //{
        //    var labProject_Database = _context.Pratos;
        //    foreach (Prato p in labProject_Database)
        //    {
        //        p.Foto = @"../Images/Pratos/" + p.Foto.ToString();
        //        p.Nome = Truncate(p.Nome, 14);
        //    }
        //    return View(await labProject_Database.ToListAsync());
        //}


        public async Task<IActionResult> Pratos(string searchString)
        {

            ViewData["CurrentFilter"] = searchString;

            var labProject_Database = from p in _context.Pratos select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                labProject_Database = labProject_Database.Where(s => s.Nome.Contains(searchString));
            }

            foreach (Prato p in labProject_Database)
            {
                p.Foto = @"../Images/Pratos/" + p.Foto.ToString();
                p.Nome = Truncate(p.Nome, 14);
            }

            //    break;
            //case "Date":
            //    students = students.OrderBy(s => s.EnrollmentDate);
            //    break;
            //case "date_desc":
            //    students = students.OrderByDescending(s => s.EnrollmentDate);
            //    break;
            //default:
            //    students = students.OrderBy(s => s.LastName);
            //    break;

            return View(await labProject_Database.ToListAsync());
        }



        // GET: Pratos favoritos
        public async Task<IActionResult> PratosFavoritos()
        {
            if (Convert.ToBoolean(TempData["Autenticado"]))
            {

                var labProject_Database = (from pratos in _context.Pratos
                                           join cliente in _context.Clientes on Convert.ToInt32(TempData["id"]) equals cliente.UtilizadorId
                                           join pratofavorito in _context.PratoClientes on pratos.Id equals pratofavorito.PratoId
                                           where pratofavorito.ClienteId == cliente.Id
                                           select pratos);
                foreach (Prato p in labProject_Database)
                {
                    p.Foto = @"../Images/Pratos/" + p.Foto.ToString();
                    p.Nome = Truncate(p.Nome, 14);
                }
                return View(await labProject_Database.ToListAsync());


            }
            else
            {
                return NotFound();
            }


        }


        //public async Task<IActionResult> VerPrato(int? id)
        //{
        //    var prato = (from pratos in _context.Pratos
        //                               where pratos.Id == id
        //                               select pratos);
            

        //    TempData["PratoEscolhido"] = prato.ToList()[0];

        //    var labProject_Database = _context.Restaurantes;



        //    return View(await labProject_Database.ToListAsync());


        //}

        public async Task<IActionResult> VerPrato(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prato = (from pratos in _context.Pratos
                         where pratos.Id == id
                         select pratos);

           
            Prato _p = prato.ToList()[0];
            //_p.Nome = Truncate(_p.Nome, 1);
            ViewData["PratoEscolhido"] = _p;

        


            //var labProject_Database = _context.Restaurantes;
            var labProject_Database = (from restaurante in _context.Restaurantes
                                       join restaurantePrato in _context.RestaurantePratos on restaurante.Id equals restaurantePrato.RestauranteId
                                       where restaurantePrato.PratoId == id
                                       select restaurante);



            return View(await labProject_Database.Include(p => p.Utilizador).Include(p => p.RestaurantePratos).ToListAsync());
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
        public async Task<IActionResult> Create([Bind("Id,Nome,Foto,TipoPratoId")] Prato prato)
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Foto,TipoPratoId")] Prato prato)
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
