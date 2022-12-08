using Proyecto_Tienda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_Tienda.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            MantenimientoCliente mc = new MantenimientoCliente();
            return View(mc.RecuperarTodos());
        }



        public ActionResult Alta()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Alta(FormCollection collection)
        {
            MantenimientoCliente mc = new MantenimientoCliente();
            Cliente cliente = new Cliente
            {
                Nombre = collection["Nombre"],
                Direccion = collection["Direccion"],

            };
            mc.Alta(cliente);
            return RedirectToAction("Index");
        }

        public ActionResult Baja(int id)
        {
            MantenimientoCliente mc = new MantenimientoCliente();
            mc.Borrar(id);
            return RedirectToAction("Index");
        }

        public ActionResult Modificacion(int id)
        {
            MantenimientoCliente mc = new MantenimientoCliente();
            Cliente cliente = mc.Recuperar(id);
            return View(cliente);
        }

        [HttpPost]
        public ActionResult Modificacion(FormCollection collection)
        {
            MantenimientoCliente mc = new MantenimientoCliente();
            Cliente cliente = new Cliente
            {
                Id = int.Parse(collection["Id"].ToString()),
                Nombre = collection["Nombre"].ToString(),
                Direccion= collection["Direccion"].ToString(),




            };
            mc.Modificar(cliente);
            return RedirectToAction("Index");
        }
    }
}