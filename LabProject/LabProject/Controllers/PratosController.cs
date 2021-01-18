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
    public class PratosController : Controller
    {
        private readonly LabProject_Context _context;
        private IWebHostEnvironment _he;

        public PratosController(LabProject_Context context)
        {
            _context = context;
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



        // GET: Pratos
        public async Task<IActionResult> Index()
        {
            string Status = CheckStatus();

            switch (Status)
            {
                case "Admin":
                case "Cliente":
                case "Restaurante":
                case "NaoAutenticado":
                    var labProject_Database = _context.Pratos.Include(p => p.TipoPrato);
                    labProject_Database.Include(p => p.RestaurantePratos.Take(1));


                    return View(await labProject_Database.ToListAsync());

                default:
                    return RedirectToAction("Bloqueado", new RouteValueDictionary(
                  new { controller = "Utilizador", action = "Bloqueado", Motivo = Status }));
            }




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


        public async Task<IActionResult> Pratos(string searchString, DateTime SearchData)
        {
            string Status = CheckStatus();

            switch (Status)
            {
                case "Admin":
                case "Cliente":
                case "Restaurante":
                case "NaoAutenticado":

                    ViewData["CurrentFilter"] = searchString;

                    if (SearchData == DateTime.MinValue)
                        SearchData = DateTime.Now.Date;

                    ViewData["SearchData"] = SearchData.ToString("MM-dd-yyyy");

                    var labProject_Database = _context.Pratos.Where(t => _context.RestaurantePratos.Any(a => a.PratoId == t.Id && a.Dia == SearchData));


                    if (!String.IsNullOrEmpty(searchString))
                    {
                        labProject_Database = labProject_Database.Where(s => s.Nome.ToUpper().Contains(searchString.ToUpper()) || s.TipoPrato.Nome.ToUpper().Contains(searchString.ToUpper()));

                    }


                    foreach (Prato p in labProject_Database)
                    {
                        p.Foto = @"../Images/Pratos/" + p.Foto.ToString();
                        p.Nome = Truncate(p.Nome, 14);
                    }


                    return View(await labProject_Database.ToListAsync());


                    return View(await labProject_Database.ToListAsync());

                default:
                    return RedirectToAction("Bloqueado", new RouteValueDictionary(
                  new { controller = "Utilizador", action = "Bloqueado", Motivo = Status }));
            }



        }
        public async Task<IActionResult> MeusPratos(string searchString, DateTime SearchData)
        {

            string Status = CheckStatus();

            switch (Status)
            {
                
                case "Restaurante":
                    ViewData["CurrentFilter"] = searchString;

                    if (SearchData == DateTime.MinValue)
                        SearchData = DateTime.Now.Date;

                    ViewData["SearchData"] = SearchData.ToString("MM-dd-yyyy");


                    if (HttpContext.Session.GetString("Id") == null)
                    {
                        return NotFound();
                    }

                    int id = Convert.ToInt32(HttpContext.Session.GetString("Id"));


                    RestaurantePratosPertence Restaurante = new RestaurantePratosPertence();

                    Restaurante.Restaurante = await _context.Restaurantes
                        .Include(r => r.Utilizador)
                                .FirstOrDefaultAsync(m => m.UtilizadorId == id);

                    if (Restaurante.Restaurante == null)
                    {
                        return NotFound();
                    }




                    var Pratos = (from prato in _context.Pratos
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
                                      Dia = restaurantePrato.Dia
                                  }).OrderByDescending(x => x.Dia);


                    Restaurante.Pratos = Pratos.ToList();

                    if (!String.IsNullOrEmpty(searchString))
                    {
                        Restaurante.Pratos = Pratos.Where(s => s.Nome.ToUpper().Contains(searchString.ToUpper()) || s.TipoPrato.Nome.ToUpper().Contains(searchString.ToUpper())).ToList();
                    }




                    return View(Restaurante);
                case "NaoAutenticado":
                case "Admin":
                case "Cliente":
                    return RedirectToAction("Login", "Utilizador");

                default:
                    return RedirectToAction("Bloqueado", new RouteValueDictionary(
                  new { controller = "Utilizador", action = "Bloqueado", Motivo = Status }));
            }

           

        }





        public async Task<IActionResult> MeusPratosHoje()
        {
            string Status = CheckStatus();

            switch (Status)
            {
                case "Restaurante":
                    
            if (HttpContext.Session.GetString("Id") == null)
            {
                return NotFound();
            }

            int id = Convert.ToInt32(HttpContext.Session.GetString("Id"));


            RestaurantePratosPertence Restaurante = new RestaurantePratosPertence();

            Restaurante.Restaurante = await _context.Restaurantes
                .Include(r => r.Utilizador)
                        .FirstOrDefaultAsync(m => m.UtilizadorId == id);

            if (Restaurante.Restaurante == null)
            {
                return NotFound();
            }




            List<PratoIndividual> Pratos = await (from prato in _context.Pratos
                                                  join restaurantePrato in _context.RestaurantePratos on prato.Id equals restaurantePrato.PratoId
                                                  where restaurantePrato.RestauranteId == Restaurante.Restaurante.Id && restaurantePrato.Dia == DateTime.Now.Date
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


            return View(Restaurante);
                case "Admin":
                case "Cliente":
                case "NaoAutenticado":
                    return RedirectToAction("Login", "Utilizador");

                default:
                    return RedirectToAction("Bloqueado", new RouteValueDictionary(
                  new { controller = "Utilizador", action = "Bloqueado", Motivo = Status }));
            }




        }


        public async Task<IActionResult> CriarHoje(string searchString, DateTime SearchData)
        {
            string Status = CheckStatus();

            switch (Status)
            {
                case "Restaurante":
                    ViewData["CurrentFilter"] = searchString;

                    if (SearchData == DateTime.MinValue)
                        SearchData = DateTime.Now.Date;

                    ViewData["SearchData"] = SearchData.ToString("MM-dd-yyyy");


                    if (HttpContext.Session.GetString("Id") == null)
                    {
                        return NotFound();
                    }

                    int id = Convert.ToInt32(HttpContext.Session.GetString("Id"));



                    RestaurantePratosPertence Restaurante = new RestaurantePratosPertence();

                    Restaurante.Restaurante = await _context.Restaurantes
                        .Include(r => r.Utilizador)
                                .FirstOrDefaultAsync(m => m.UtilizadorId == id);

                    if (Restaurante.Restaurante == null)
                    {
                        return NotFound();
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

                    Restaurante.Pratos = Pratos;



                    return View(Restaurante);
                case "Admin":
                case "Cliente":
                case "NaoAutenticado":
                    return RedirectToAction("Login", "Utilizador");

                default:
                    return RedirectToAction("Bloqueado", new RouteValueDictionary(
                  new { controller = "Utilizador", action = "Bloqueado", Motivo = Status }));
            }

            
        }

        public async Task<IActionResult> CriarHojeNovo()
        {
            string Status = CheckStatus();

            switch (Status)
            {
                case "Restaurante":
                    ViewData["roles"] = _context.TipoPratos.ToList();
                    return View();

                case "Cliente":
                case "Admin":
                case "NaoAutenticado":
                    return RedirectToAction("Login", "Utilizador");

                default:
                    return RedirectToAction("Bloqueado", new RouteValueDictionary(
                  new { controller = "Utilizador", action = "Bloqueado", Motivo = Status }));
            }               
        }

        public async Task<IActionResult> AddHojeNovo([Bind("Id", "Foto", "TipoPratoId", "Nome", "Descricao", "Dia", "Preco")] PratoIndividual pratoIndividual, IFormFile files)
        {
            
            //if (ModelState.IsValid)
            //{
            try
            {
                try
                {
                    if (files != null)
                    {
                        Random numAleatorio = new Random();
                        int valorInteiro = numAleatorio.Next(10000, 100000);
                        string NomeFicheiro = HttpContext.Session.GetString("Id") + valorInteiro + Path.GetFileName(files.FileName);

                        string uploads = Path.Combine(_he.ContentRootPath, "wwwroot/Images/Pratos/", NomeFicheiro);

                        FileStream fs = new FileStream(uploads, FileMode.Create);

                        files.CopyTo(fs);
                        fs.Close();

                        pratoIndividual.Foto = Path.GetFileName(files.FileName); // opiniao dar id + nome da imagem pq as imagens podem ter nomes iguais
                    }

                }
                catch (Exception)
                {


                }

           

                int restauranteID = Convert.ToInt32((from Restaurante in _context.Restaurantes
                                                     where Restaurante.UtilizadorId == Convert.ToInt32(HttpContext.Session.GetString("Id"))
                                                     select Restaurante.Id).FirstOrDefault());



                pratoIndividual.Foto = "FOTOTEMPORARIA";

                Prato NovoPrato = new Prato();
                NovoPrato.Foto = pratoIndividual.Foto;
                NovoPrato.Nome = pratoIndividual.Nome;
                NovoPrato.TipoPratoId = pratoIndividual.TipoPratoId;

                _context.Pratos.Add(NovoPrato);
                await _context.SaveChangesAsync();




                RestaurantePrato NovoPrato1 = new RestaurantePrato();
                NovoPrato1.Descricao = pratoIndividual.Descricao;
                NovoPrato1.Foto = pratoIndividual.Foto;
                NovoPrato1.Preco = pratoIndividual.Preco;
                NovoPrato1.PratoId = NovoPrato.Id;
                NovoPrato1.RestauranteId = restauranteID;
                NovoPrato1.Dia = pratoIndividual.Dia;

                _context.RestaurantePratos.Add(NovoPrato1);
                await _context.SaveChangesAsync();



            }
            catch (DbUpdateConcurrencyException)
            {

            }
            return RedirectToAction("Index", "Home");
            //}

            //return RedirectToAction("Index", "Home");
        }





        public async Task<IActionResult> SubmeterPratoExistente(int? id)
        {
            string Status = CheckStatus();

            switch (Status)
            {
                case "Restaurante":
                    if (id == null)
                    {
                        return NotFound();
                    }

                    PratoIndividual Prato = await (from prato in _context.Pratos
                                                   join restaurantePrato in _context.RestaurantePratos on prato.Id equals restaurantePrato.PratoId
                                                   join restaurantes in _context.Restaurantes on restaurantePrato.RestauranteId equals restaurantes.Id
                                                   where id == prato.Id && restaurantes.UtilizadorId == Convert.ToInt32(HttpContext.Session.GetString("Id"))
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
                                                   }).FirstOrDefaultAsync();



                    return View(Prato);

                case "Admin":
                case "Cliente":
                case "NaoAutenticado":
                    return RedirectToAction("Login", "Utilizador");

                default:
                    return RedirectToAction("Bloqueado", new RouteValueDictionary(
                  new { controller = "Utilizador", action = "Bloqueado", Motivo = Status }));
            }


          
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPratoExistente([Bind("Id", "Foto", "Name", "Descricao", "Dia", "Preco")] RestaurantePrato restaurantePrato, IFormFile files)
        {
            restaurantePrato.Foto = (TempData["FotoPratoTemp"]).ToString();
            //if (ModelState.IsValid)
            //{
            try
            {
                try
                {
                    if (files != null)
                    {
                        Random numAleatorio = new Random();
                        int valorInteiro = numAleatorio.Next(10000, 100000);
                        string NomeFicheiro = HttpContext.Session.GetString("Id") + valorInteiro + Path.GetFileName(files.FileName);

                        string uploads = Path.Combine(_he.ContentRootPath, "wwwroot/Images/Pratos/", NomeFicheiro);

                        FileStream fs = new FileStream(uploads, FileMode.Create);

                        files.CopyTo(fs);
                        fs.Close();

                        restaurantePrato.Foto = Path.GetFileName(files.FileName); // opiniao dar id + nome da imagem pq as imagens podem ter nomes iguais
                    }

                }
                catch (Exception)
                {


                }

                Restaurante p;

                int restauranteID = Convert.ToInt32((from Restaurante in _context.Restaurantes
                                                     where Restaurante.UtilizadorId == Convert.ToInt32(HttpContext.Session.GetString("Id"))
                                                     select Restaurante.Id).FirstOrDefault());

                RestaurantePrato NovoPrato = new RestaurantePrato();
                NovoPrato.Descricao = restaurantePrato.Descricao;
                NovoPrato.Foto = restaurantePrato.Foto;
                NovoPrato.Preco = restaurantePrato.Preco;
                NovoPrato.PratoId = restaurantePrato.Id;
                NovoPrato.RestauranteId = restauranteID;
                NovoPrato.Dia = restaurantePrato.Dia;

                _context.RestaurantePratos.Add(NovoPrato);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

            }
            return RedirectToAction("Index", "Home");
            //}

            //return RedirectToAction("Index", "Home");
        }




        // GET: Pratos favoritos
        public async Task<IActionResult> PratosFavoritos(string searchString)
        {
            string Status = CheckStatus();

            switch (Status)
            {
                case "Cliente":
                
                    ViewData["CurrentFilter"] = searchString;

                    var labProject_Database = (from pratos in _context.Pratos
                                               join cliente in _context.Clientes on Convert.ToInt32(HttpContext.Session.GetString("Id")) equals cliente.UtilizadorId
                                               join pratofavorito in _context.PratoClientes on pratos.Id equals pratofavorito.PratoId
                                               where pratofavorito.ClienteId == cliente.Id
                                               select pratos);

                    if (!String.IsNullOrEmpty(searchString))
                    {
                        labProject_Database = labProject_Database.Where(s => s.Nome.ToUpper().Contains(searchString.ToUpper()) || s.TipoPrato.Nome.ToUpper().Contains(searchString.ToUpper()));

                    }

                    foreach (Prato p in labProject_Database)
                    {
                        p.Foto = @"../Images/Pratos/" + p.Foto.ToString();
                        p.Nome = Truncate(p.Nome, 14);
                    }


                    return View(await labProject_Database.ToListAsync());

                case "Admin":
                case "Restaurante":
                case "NaoAutenticado":
                    return RedirectToAction("Login", "Utilizador");

                default:
                    return RedirectToAction("Bloqueado", new RouteValueDictionary(
                  new { controller = "Utilizador", action = "Bloqueado", Motivo = Status }));
            }




        }


       

        public async Task<IActionResult> VerPrato(int? id, DateTime? SearchData)
        {
            string Status = CheckStatus();

            switch (Status)
            {
                case "Admin":
                case "Cliente":
                case "Restaurante":
                case "NaoAutenticado":
                    if (SearchData == DateTime.MinValue || SearchData == null)
                        SearchData = DateTime.Now.Date;

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
                                               where restaurantePrato.PratoId == id && restaurantePrato.Dia == SearchData
                                               select restaurante);



                    return View(await labProject_Database.Include(p => p.Utilizador).Include(p => p.RestaurantePratos).ToListAsync());

                default:
                    return RedirectToAction("Bloqueado", new RouteValueDictionary(
                  new { controller = "Utilizador", action = "Bloqueado", Motivo = Status }));
            }


          

           
        }



        private bool PratoExists(int id)
        {
            return _context.Pratos.Any(e => e.Id == id);
        }
    }
}
