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
using Microsoft.AspNetCore.Routing;

namespace LabProject.Controllers
{
    public class AvisosController : Controller
    {
        private readonly LabProject_Context _context;

        public AvisosController(LabProject_Context context)
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

        // GET: Avisos
        public async Task<IActionResult> Index()
        {

            string Status = CheckStatus();

            switch (Status)
            {
                case "Cliente":
                    var labProject_Database = (from Avisos in _context.Avisos
                                               join clienteAviso in _context.ClienteAvisos on Avisos.Id equals clienteAviso.AvisoId
                                               join cliente in _context.Clientes on Convert.ToInt32(TempData["id"]) equals cliente.UtilizadorId
                                               where clienteAviso.ClienteId == cliente.Id
                                               select Avisos);



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

       

        private bool AvisoExists(int id)
        {
            return _context.Avisos.Any(e => e.Id == id);
        }
    }
}
