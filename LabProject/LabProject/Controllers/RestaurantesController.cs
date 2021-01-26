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
using Microsoft.AspNetCore.Routing;

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


        public string CheckStatus()
        {
            string _id = HttpContext.Session.GetString("Id");

            if (_id == null)
                return "NaoAutenticado";

            try
            {
                int id = Convert.ToInt32(_id);

                var Utilizador = (from utilizador in _context.Utilizadors
                                  where utilizador.Id == id
                                  select utilizador).FirstOrDefault();
                if (Utilizador.Bloqueado == true)
                    return "Utilizador Bloqueado. Motivo: " + Utilizador.Motivo;

            }
            catch { }

            return HttpContext.Session.GetString("Tipo");
        }


        public async Task<IActionResult> ListarRestaurantesPro()
        {
            string Status = CheckStatus();

            switch (Status)
            {
                case "Admin":
                    var labProject_Context = _context.Restaurantes.Include(r => r.Utilizador).Where(r => r.Aprovado == false);
                    if (labProject_Context.Count() == 0)
                    {
                        return RedirectToAction("SemResultado", "Utilizador");
                    }
                    return View(await labProject_Context.ToListAsync());

                case "Cliente":
                case "Restaurante":
                case "NaoAutenticado":
                    return RedirectToAction("Login", "Utilizador");

                default:
                    return RedirectToAction("Bloqueado", new RouteValueDictionary(
                  new { controller = "Utilizador", action = "Bloqueado", Motivo = Status }));
            }



        }



        [HttpGet]
        public async Task<IActionResult> SetAprovado(int id, bool aprovado)
        {
            string Status = CheckStatus();

            switch (Status)
            {
                case "Admin":
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

                case "Cliente":
                case "Restaurante":
                case "NaoAutenticado":
                    return RedirectToAction("Login", "Utilizador");

                default:
                    return RedirectToAction("Bloqueado", new RouteValueDictionary(
                  new { controller = "Utilizador", action = "Bloqueado", Motivo = Status }));
            }




        }


        public async Task<IActionResult> VerRestaurante(int? id, string searchString, DateTime SearchData)
        {

            string Status = CheckStatus();

            switch (Status)
            {
                case "Cliente":
                case "Restaurante":
                case "NaoAutenticado":
                case "Admin":
                    ViewData["CurrentFilter"] = searchString;

                    if (SearchData == DateTime.MinValue)
                        SearchData = DateTime.Now.Date;

                    ViewData["SearchData"] = SearchData.ToString("MM-dd-yyyy");

                    if (id == null)
                    {
                        return RedirectToAction("Bloqueado", new RouteValueDictionary(
                        new { controller = "Utilizador", action = "Bloqueado", Motivo = "ID de Restaurante Inválida" }));
                    }

                    RestaurantePratosPertence Restaurante = new RestaurantePratosPertence();

                    Restaurante.Restaurante = await _context.Restaurantes
                        .Include(r => r.Utilizador)
                        .FirstOrDefaultAsync(m => m.Id == id);

                    if (Restaurante.Restaurante == null)
                    {
                        return RedirectToAction("Bloqueado", new RouteValueDictionary(
                         new { controller = "Utilizador", action = "Bloqueado", Motivo = "Não foi encontrado o Restaurante" }));
                    }




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
     

                default:
                    return RedirectToAction("Bloqueado", new RouteValueDictionary(
                  new { controller = "Utilizador", action = "Bloqueado", Motivo = Status }));
            }




        }




        public async Task<IActionResult> EditRes()
        {
            string Status = CheckStatus();

            switch (Status)
            {
                case "Restaurante":
                    if (HttpContext.Session.GetString("Id") == null)
                    {
                        return RedirectToAction("Bloqueado", new RouteValueDictionary(
                  new { controller = "Utilizador", action = "Bloqueado", Motivo = "Algo deu Errado. Por favor reinicie a página." }));
                    }

                    int id = Convert.ToInt32(HttpContext.Session.GetString("Id"));


                    var restaurantes = await _context.Restaurantes.ToListAsync();
                    var restaurante = restaurantes.First(f => f.UtilizadorId == id);
                    if (restaurante == null)
                    {
                        return RedirectToAction("Bloqueado", new RouteValueDictionary(
                 new { controller = "Utilizador", action = "Bloqueado", Motivo = "Algo deu Errado. Por favor reinicie a página." }));
                    }
                    var utilizador = await _context.Utilizadors.FindAsync(restaurante.UtilizadorId);

                    var Restaurante = new RestauranteCompleto();
                    Restaurante.RestauranteCompletoSet(restaurante, utilizador);

                    return View(Restaurante);

                case "Cliente":
                case "Admin":
                case "NaoAutenticado":
                    return RedirectToAction("Login", "Utilizador");

                default:
                    return RedirectToAction("Bloqueado", new RouteValueDictionary(
                  new { controller = "Utilizador", action = "Bloqueado", Motivo = Status }));
            }




        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditRes([Bind("Id", "UtilizadorId", "Name", "Email", "Username", "Password", "Telefone", "Morada", "HoraAbertura", "HoraFecho", "DiaDescanso")] RestauranteCompleto restaurante, IFormFile files)
        {

                    if (ModelState.IsValid)
                    {
                        List<Utilizador> existe = _context.Utilizadors.AsNoTracking().ToList();
                
                        var u = existe.FirstOrDefault(u => ((!(u.Id.Equals(restaurante.UtilizadorId)) && (u.Username.Equals(restaurante.Username)) || (!(u.Id.Equals(restaurante.UtilizadorId)) && (u.Email.Equals(restaurante.Email))))));

                        if (u==null)
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

                                        restaurante.Imagem = NomeFicheiro; // opiniao dar id + nome da imagem pq as imagens podem ter nomes iguais
                                        HttpContext.Session.SetString("Imagem", restaurante.Imagem);
                                    }

                                }
                                catch (Exception)
                                {


                                }
                                restaurante.Imagem = HttpContext.Session.GetString("Imagem");
                                restaurante.Aprovado = true;
                                HttpContext.Session.SetString("Email", restaurante.Email);
                                HttpContext.Session.SetString("Name", restaurante.Name);

                                _context.Update(restaurante.GetUtilizador());
                                await _context.SaveChangesAsync();
                                _context.Update(restaurante.GetRestaurante());
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
                        else
                            ModelState.AddModelError("Username", "This user already exists");
                    }
                    return View(restaurante);

               



        }



        private bool RestauranteExists(int id)
        {
            return _context.Restaurantes.Any(e => e.Id == id);
        }
    }
}
