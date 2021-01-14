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
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace LabProject.Controllers
{
    public class UtilizadorController : Controller
    {
        private readonly LabProject_Context _context;
        private IWebHostEnvironment _he;

        public UtilizadorController(LabProject_Context context, IWebHostEnvironment e)
        {
            _context = context;
            _he = e;
        }

        //Login
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (ModelState.IsValid)
            {
                //Parte com cookies
                Utilizador u = _context.Utilizadors.SingleOrDefault(u => u.Username == username && u.Password == password);
                if (u == null)
                {
                    ModelState.AddModelError("Username", "Username or password are wrong");
                }
                else
                {
                    HttpContext.Session.SetString("Utilizador", username);
                    HttpContext.Session.SetString("Email", u.Email);
                    HttpContext.Session.SetString("Name", u.Name);
                    try
                    {
                        HttpContext.Session.SetString("Imagem", u.Imagem);
                    }
                    catch (Exception)
                    {
                    }
                    HttpContext.Session.SetString("Id", Convert.ToString(u.Id));
                    var CheckUtilizador = (from Clientes in _context.Clientes
                                           where Clientes.UtilizadorId == u.Id
                                           select Clientes);

                    if (CheckUtilizador.ToList().Count > 0)
                    {
                        HttpContext.Session.SetString("Tipo", "Cliente");
                    }
                    else
                    {
                        var CheckUtilizador2 = (from Restaurantes in _context.Restaurantes
                                                where Restaurantes.UtilizadorId == u.Id
                                                select Restaurantes);

                        if (CheckUtilizador2.ToList().Count > 0)
                        {
                            HttpContext.Session.SetString("Tipo", "Restaurante");

                        }
                        else
                        {
                            HttpContext.Session.SetString("Tipo", "Admin");

                        }
                    }
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Response.Cookies.Delete(".LabProject.Session");
            return RedirectToAction("Index", "Home");
        }
        //Registar
        // GET: Utilizador/Create
        public IActionResult Registar()
        {
            return View();
        }

        // POST: Utilizador/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registar([Bind("Id,Name,Email,Username,Password")] Utilizador utilizador, IFormFile files)   //ESTE ESTA FUNCIONAL
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Random numAleatorio = new Random();
                    int valorInteiro = numAleatorio.Next(10000, 100000);
                    string NomeFicheiro = valorInteiro + Path.GetFileName(files.FileName);

                    string uploads = Path.Combine(_he.ContentRootPath, "wwwroot/Images/Utilizadores/", NomeFicheiro);

                    FileStream fs = new FileStream(uploads, FileMode.Create);

                    files.CopyTo(fs);
                    fs.Close();

                    utilizador.Imagem = Path.GetFileName(files.FileName); // opiniao dar id + nome da imagem pq as imagens podem ter nomes iguais
                    HttpContext.Session.SetString("Imagem", utilizador.Imagem);
                }
                catch (Exception)
                {
                }
                _context.Add(utilizador);
                await _context.SaveChangesAsync();
                int clienteId = utilizador.Id;
                Cliente cliente = new Cliente();
                cliente.UtilizadorId = clienteId;
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction("Login", "Utilizador");
            }
            return View(utilizador);
        }
        //GET Registar2
        public IActionResult Registar2()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registar2([Bind("Id,Name,Email,Username,Password,Telefone,Morada,HoraAbertura,HoraFecho,DiaDescanso")] RestauranteCompleto restaurante, IFormFile files)
        {
            if (ModelState.IsValid)
            {
                Utilizador utilizador = restaurante.GetUtilizador();
                try
                {
                    Random numAleatorio = new Random();
                    int valorInteiro = numAleatorio.Next(10000, 100000);
                    string NomeFicheiro = valorInteiro + Path.GetFileName(files.FileName);

                    string uploads = Path.Combine(_he.ContentRootPath, "wwwroot/Images/Utilizadores/", NomeFicheiro);

                    FileStream fs = new FileStream(uploads, FileMode.Create);

                    files.CopyTo(fs);
                    fs.Close();

                    utilizador.Imagem = Path.GetFileName(files.FileName);
                    HttpContext.Session.SetString("Imagem", utilizador.Imagem);
                }
                catch (Exception)
                {
                }
                _context.Add(utilizador);
                await _context.SaveChangesAsync();
                int utilizadorId = utilizador.Id;
                Restaurante restaurante1 = restaurante.GetRestaurante();
                restaurante1.UtilizadorId = utilizadorId;
                _context.Add(restaurante1);
                await _context.SaveChangesAsync();
                return RedirectToAction("Login", "Utilizador");
            }
            return View();
        }

        //GET
        public IActionResult RegistarAdmin()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistarAdmin([Bind("Id,Name,Email,Username,Password")] Utilizador utilizador, IFormFile files)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Random numAleatorio = new Random();
                    int valorInteiro = numAleatorio.Next(10000, 100000);
                    string NomeFicheiro = valorInteiro + Path.GetFileName(files.FileName);

                    string uploads = Path.Combine(_he.ContentRootPath, "wwwroot/Images/Utilizadores/", NomeFicheiro);

                    FileStream fs = new FileStream(uploads, FileMode.Create);

                    files.CopyTo(fs);
                    fs.Close();

                    utilizador.Imagem = Path.GetFileName(files.FileName);
                    HttpContext.Session.SetString("Imagem", utilizador.Imagem);
                }
                catch (Exception)
                {
                }
                _context.Add(utilizador);
                await _context.SaveChangesAsync();
                int adminId = utilizador.Id;
                Administrador admin = new Administrador();
                admin.UtilizadorId = adminId;
                _context.Add(admin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(utilizador);
        }

        //Nao deve ser preciso o que esta para baixo



        // GET: Utilizador
        public async Task<IActionResult> Index()
        {
            return View(await _context.Utilizadors.ToListAsync());
        }


        public async Task<IActionResult> VerUtilizadores(string tipo)
        {
            if (tipo != "Restaurantes")
            {
                var Pessoas = (from cliente in _context.Clientes
                              join Utilizador in _context.Utilizadors on cliente.UtilizadorId equals Utilizador.Id
                              select Utilizador);

                return View(await Pessoas.ToListAsync());
            }
            else
            {
                var Pessoas = (from restaurante in _context.Restaurantes
                               join Utilizador in _context.Utilizadors on restaurante.UtilizadorId equals Utilizador.Id
                               select Utilizador);

                return View(await Pessoas.ToListAsync());

            }


            
        }

        // GET: Utilizador/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utilizador = await _context.Utilizadors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (utilizador == null)
            {
                return NotFound();
            }

            return View(utilizador);
        }

        // GET: Utilizador/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Utilizador/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,Username,Password,Foto,Bloqueado,Motivo,Notificacao")] Utilizador utilizador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(utilizador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(utilizador);
        }




        // GET: Utilizador/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utilizador = await _context.Utilizadors.FindAsync(id);
            if (utilizador == null)
            {
                return NotFound();
            }
            return View(utilizador);
        }

        public async Task<IActionResult> EditOwn()
        {
            if (HttpContext.Session.GetString("Utilizador") != null)
            {
                int id = Convert.ToInt32(HttpContext.Session.GetString("Id"));
                //if (id == null)
                //{
                //    return NotFound();
                //}

                var utilizador = await _context.Utilizadors.FindAsync(id);
                if (utilizador == null)
                {
                    return NotFound();
                }
                return View(utilizador);

            }
            else
            {
                return NotFound();
            }
        }



        // POST: Utilizador/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,Username,Password,Foto,Bloqueado,Motivo,Notificacao")] Utilizador utilizador)
        {
            if (id != utilizador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(utilizador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UtilizadorExists(utilizador.Id))
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
            return View(utilizador);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditOwn(int id, [Bind("Id,Name,Email,Username,Password,Notificacao")] Utilizador utilizador, IFormFile files)
        {
            if (id != utilizador.Id)
            {
                return NotFound();
            }

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

                            utilizador.Imagem = Path.GetFileName(files.FileName); // opiniao dar id + nome da imagem pq as imagens podem ter nomes iguais
                            HttpContext.Session.SetString("Imagem", utilizador.Imagem);
                        }
                    }
                    catch (Exception)
                    {

                    }
                    utilizador.Imagem = HttpContext.Session.GetString("Imagem");
                    _context.Update(utilizador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UtilizadorExists(utilizador.Id))
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
            return View(utilizador);
        }

        // GET: Utilizador/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utilizador = await _context.Utilizadors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (utilizador == null)
            {
                return NotFound();
            }

            return View(utilizador);
        }

        // POST: Utilizador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var utilizador = await _context.Utilizadors.FindAsync(id);
            _context.Utilizadors.Remove(utilizador);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UtilizadorExists(int id)
        {
            return _context.Utilizadors.Any(e => e.Id == id);
        }
    }
}
