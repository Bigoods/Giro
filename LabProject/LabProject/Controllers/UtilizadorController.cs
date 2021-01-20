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
using Microsoft.AspNetCore.Routing;
using System.Net;
using System.Net.Mail;

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
                    HttpContext.Session.SetString("Bloqueado", u.Bloqueado.ToString());
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
                    Cliente CheckUtilizador = (from Clientes in _context.Clientes
                                               where Clientes.UtilizadorId == u.Id
                                               select Clientes).FirstOrDefault();

                    if (CheckUtilizador != null)
                    {
                        HttpContext.Session.SetString("idCliente", CheckUtilizador.Id.ToString());

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

                            if (u.Bloqueado)
                            {

                            }


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

        public IActionResult Bloqueado(string Motivo)
        {
            if (Motivo == null)
                return RedirectToAction("Login", "Utilizador");
            if (Motivo.StartsWith("#"))
                return View(model: "Porfavor, verifique o seu Email!");

            return View(model: Motivo);
        }

        public IActionResult SemResultado()
        {
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

        private static Random random = new Random();
        public string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
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

                    utilizador.Imagem = NomeFicheiro; // opiniao dar id + nome da imagem pq as imagens podem ter nomes iguais
                    utilizador.Bloqueado = true;
                    utilizador.Motivo = "#" + RandomString(10);
                    HttpContext.Session.SetString("Imagem", utilizador.Imagem);


                    // ENVIA EMAIL!!!!

                    var fromAddress = new MailAddress("labproject190121@gmail.com", "Jiro");
                    var toAddress = new MailAddress(utilizador.Email, utilizador.Name);
                    const string fromPassword = "a1b2c3~~";
                    const string subject = "Verificação Email";
                    string body = "Utilizador/VerificarConta?ver=" + utilizador.Motivo;

                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                    };
                    using (var message = new MailMessage(fromAddress, toAddress)
                    {
                        Subject = subject,
                        Body = body
                    })
                    {
                        smtp.Send(message);
                    }




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

        public IActionResult VerificarConta(string Ver)
        {
            if (Ver == null)
                return RedirectToAction("Login", "Utilizador");
            if (Ver.StartsWith("#"))
            {

                var Utilizador = _context.Utilizadors.Where(u => u.Motivo == Ver).FirstOrDefault();
                if (Utilizador != null)
                {
                    Utilizador.Bloqueado = false;
                    Utilizador.Motivo = "";
                    _context.Update(Utilizador);
                    _context.SaveChanges();

                    return RedirectToAction("Login", "Utilizador");
                }

            }
            return RedirectToAction("Bloqueado", new RouteValueDictionary(
                  new { controller = "Utilizador", action = "Bloqueado", Motivo = "Codigo de Verificação Errado!" }));


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

                    utilizador.Imagem = NomeFicheiro;
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
            string Status = CheckStatus();

            switch (Status)
            {
                case "Admin":
                    return View();

                case "Cliente":
                case "Restaurante":
                case "NaoAutenticado":
                    return RedirectToAction("Login", "Utilizador");

                default:
                    return RedirectToAction("Bloqueado", new RouteValueDictionary(
                  new { controller = "Utilizador", action = "Bloqueado", Motivo = Status }));
            }


        }


        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistarAdmin([Bind("Id,Name,Email,Username,Password")] Utilizador utilizador, IFormFile files)
        {
            string Status = CheckStatus();

            switch (Status)
            {
                case "Admin":
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

                            utilizador.Imagem = NomeFicheiro;
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


                case "Cliente":
                case "Restaurante":
                case "NaoAutenticado":
                    return RedirectToAction("Login", "Utilizador");

                default:
                    return RedirectToAction("Bloqueado", new RouteValueDictionary(
                  new { controller = "Utilizador", action = "Bloqueado", Motivo = Status }));
            }


        }



        public async Task<IActionResult> VerUtilizadores(string tipo)
        {
            string Status = CheckStatus();

            switch (Status)
            {
                case "Admin":
                    if (tipo == "Desbloquear")
                    {
                        ViewBag.isClient = tipo;
                        return View(await _context.Utilizadors.Where(x => x.Bloqueado == true).ToListAsync());

                    }
                    else if (tipo == "Restaurantes")
                    {
                        var Pessoas = (from restaurante in _context.Restaurantes
                                       join Utilizador in _context.Utilizadors on restaurante.UtilizadorId equals Utilizador.Id
                                       select Utilizador);
                        ViewBag.isClient = tipo;
                        return View(await Pessoas.Where(x => x.Bloqueado == false).ToListAsync());

                    }
                    else
                    {
                        var Pessoas = (from cliente in _context.Clientes
                                       join Utilizador in _context.Utilizadors on cliente.UtilizadorId equals Utilizador.Id
                                       select Utilizador);
                        return View(await Pessoas.Where(x => x.Bloqueado == false).ToListAsync());
                    }

                case "Cliente":
                case "Restaurante":
                case "NaoAutenticado":
                    return RedirectToAction("Login", "Utilizador");

                default:
                    return RedirectToAction("Bloqueado", new RouteValueDictionary(
                  new { controller = "Utilizador", action = "Bloqueado", Motivo = Status }));
            }



        }

        // GET: Utilizador/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            string Status = CheckStatus();

            switch (Status)
            {
                case "Admin":
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

                case "Cliente":
                case "Restaurante":
                case "NaoAutenticado":
                    return RedirectToAction("Login", "Utilizador");

                default:
                    return RedirectToAction("Bloqueado", new RouteValueDictionary(
                  new { controller = "Utilizador", action = "Bloqueado", Motivo = Status }));
            }




        }




        public async Task<IActionResult> EditOwn()
        {
            string Status = CheckStatus();

            switch (Status)
            {
                case "Cliente":
                case "Admin":
                    int id = Convert.ToInt32(HttpContext.Session.GetString("Id"));
                    //if (id == null)
                    //{
                    //    return NotFound();
                    //}

                    var utilizador = await _context.Utilizadors.FindAsync(id);
                    if (utilizador == null)
                    {
                        return RedirectToAction("Bloqueado", new RouteValueDictionary(
                new { controller = "Utilizador", action = "Bloqueado", Motivo = "Algo deu Errado. Por favor reinicie a página." }));

                    }
                    return View(utilizador);


                case "Restaurante":
                case "NaoAutenticado":
                    return RedirectToAction("Login", "Utilizador");

                default:
                    return RedirectToAction("Bloqueado", new RouteValueDictionary(
                  new { controller = "Utilizador", action = "Bloqueado", Motivo = Status }));
            }






        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditOwn(int id, [Bind("Id,Name,Email,Username,Password,Notificacao")] Utilizador utilizador, IFormFile files)
        {


            string Status = CheckStatus();

            switch (Status)
            {
                case "Cliente":
                case "Admin":
                    if (id != utilizador.Id)
                    {
                        return RedirectToAction("Bloqueado", new RouteValueDictionary(
                        new { controller = "Utilizador", action = "Bloqueado", Motivo = "Algo deu Errado. Por favor reinicie a página." }));
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

                                    utilizador.Imagem = NomeFicheiro; // opiniao dar id + nome da imagem pq as imagens podem ter nomes iguais
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
                                return RedirectToAction("Bloqueado", new RouteValueDictionary(
                        new { controller = "Utilizador", action = "Bloqueado", Motivo = "Algo deu Errado. Por favor reinicie a página." }));
                            }
                            else
                            {
                                throw;
                            }
                        }
                        return RedirectToAction("Index", "Home");
                    }
                    return View(utilizador);


                case "Restaurante":
                case "NaoAutenticado":
                    return RedirectToAction("Login", "Utilizador");

                default:
                    return RedirectToAction("Bloqueado", new RouteValueDictionary(
                  new { controller = "Utilizador", action = "Bloqueado", Motivo = Status }));
            }

        }


        private bool UtilizadorExists(int id)
        {
            return _context.Utilizadors.Any(e => e.Id == id);
        }

        // GET: Restaurantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            string Status = CheckStatus();

            switch (Status)
            {
                case "Admin":
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

                case "Cliente":
                case "Restaurante":
                case "NaoAutenticado":
                    return RedirectToAction("Login", "Utilizador");

                default:
                    return RedirectToAction("Bloqueado", new RouteValueDictionary(
                  new { controller = "Utilizador", action = "Bloqueado", Motivo = Status }));
            }



        }

        // POST: Restaurantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string Motivo, int id)
        {
            string Status = CheckStatus();

            switch (Status)
            {
                case "Admin":

                    var utilizador = await _context.Utilizadors.FindAsync(id);
                    utilizador.Motivo = Motivo;
                    utilizador.Bloqueado = true;
                    _context.Utilizadors.Update(utilizador);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("VerUtilizadores", "Utilizador");

                case "Cliente":
                case "Restaurante":
                case "NaoAutenticado":
                    return RedirectToAction("Login", "Utilizador");

                default:
                    return RedirectToAction("Bloqueado", new RouteValueDictionary(
                  new { controller = "Utilizador", action = "Bloqueado", Motivo = Status }));
            }



        }
        public async Task<IActionResult> Desbloquear(int? id)
        {
            string Status = CheckStatus();

            switch (Status)
            {
                case "Admin":
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

                case "Cliente":
                case "Restaurante":
                case "NaoAutenticado":
                    return RedirectToAction("Login", "Utilizador");

                default:
                    return RedirectToAction("Bloqueado", new RouteValueDictionary(
                  new { controller = "Utilizador", action = "Bloqueado", Motivo = Status }));
            }



        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Desbloquear(int id)
        {
            string Status = CheckStatus();

            switch (Status)
            {
                case "Admin":

                    var utilizador = await _context.Utilizadors.FindAsync(id);

                    utilizador.Bloqueado = false;
                    utilizador.Motivo = null;
                    _context.Utilizadors.Update(utilizador);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("VerUtilizadores", "Utilizador");

                case "Cliente":
                case "Restaurante":
                case "NaoAutenticado":
                    return RedirectToAction("Login", "Utilizador");

                default:
                    return RedirectToAction("Bloqueado", new RouteValueDictionary(
                  new { controller = "Utilizador", action = "Bloqueado", Motivo = Status }));
            }
        }
    }
}
