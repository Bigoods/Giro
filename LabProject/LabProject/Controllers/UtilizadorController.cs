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
        private readonly LabProject_Database _context;
        private IWebHostEnvironment _he;


        public UtilizadorController(LabProject_Database context, IWebHostEnvironment e)
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
                Utilizador u = _context.Utilizadors.SingleOrDefault(u => u.Username == username && u.Password == password);


                if (u == null)
                {
                    ModelState.AddModelError("Username", "username or password are wrong");
                    TempData["Autenticado"] = false;
                }

                else
                {
                    // the user is authenticated
                    // the session variable "user" is created to recover the user identify at each request
                    //HttpContext.Session.SetString("Username", username); //cookies
                    TempData["username"] = username;
                    TempData["imagem"] = u.Imagem;
                    TempData["id"] = u.Id;
                    TempData["email"] = u.Email;
                    TempData["Autenticado"] = true;
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
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
        public async Task<IActionResult> Registar([Bind("Id,Name,Email,Username,Password,Imagem,Bloqueado,Motivo,Notificacao")] Utilizador utilizador)
        {
           /* if (ModelState.IsValid)
            {
                //if (Convert.ToInt32(TempData["cliente"])==1) //clientes 
                //{
                    _context.Add(utilizador);
                    int clienteId = utilizador.Id;
                    Cliente cliente = new Cliente();
                    cliente.UtilizadorId = clienteId;
                    _context.Add(cliente);
                }
                else //restaurante
                {
                    
                }
                //return RedirectToAction("Login", "Utilizadores");

                /*_context.Add(utilizador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }*/
            //return View();


            if (ModelState.IsValid)
            {
                _context.Add(utilizador);
                await _context.SaveChangesAsync();
                int clienteId = utilizador.Id;
                Cliente cliente = new Cliente();
                cliente.UtilizadorId = clienteId;
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(utilizador);
        }
        // GET: Utilizador
        public async Task<IActionResult> Index()
        {
            return View(await _context.Utilizadors.ToListAsync());
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
            if (!Convert.ToBoolean(TempData["Autenticado"]))
            {
                int id = Convert.ToInt32(TempData["id"]);
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
            public async Task<IActionResult> EditOwn(int id, [Bind("Id,Name,Email,Username,Password,Foto,Notificacao")] Utilizador utilizador, IFormFile files)
            {
                if (id != utilizador.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        string uploads = Path.Combine(_he.ContentRootPath, "wwwroot/Images/Utilizadores/", Path.GetFileName(files.FileName));

                        FileStream fs = new FileStream(uploads, FileMode.Create);

                        files.CopyTo(fs);
                        fs.Close();

                        utilizador.Imagem = Path.GetFileName(files.FileName); // opiniao dar id + nome da imagem pq as imagens podem ter nomes iguais
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
