using Proyecto_Tienda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_Tienda.Controllers
{
    public class ProveedorController : Controller
    {
        // GET: Proveedor
        public ActionResult Index()
        {
            MantenimientoProveedor mp = new MantenimientoProveedor();
            return View(mp.RecuperarTodos());
        }



        public ActionResult Alta()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Alta(FormCollection collection)
        {
            MantenimientoProveedor mp = new MantenimientoProveedor();
            Proveedores proveedores = new Proveedores
            {               
                Proveedor = collection["Proveedor"],
                Contacto = collection["Contacto"],

            };
            mp.Alta(proveedores);
            return RedirectToAction("Index");
        }

        public ActionResult Baja(int id)
        {
            MantenimientoProveedor mp = new MantenimientoProveedor();
            mp.Borrar(id);
            return RedirectToAction("Index");
        }

        public ActionResult Modificacion(int id)
        {
            MantenimientoProveedor mp= new MantenimientoProveedor();
           Proveedores proveedores= mp.Recuperar(id);
            return View(proveedores);
        }

        [HttpPost]
        public ActionResult Modificacion(FormCollection collection)
        {
            MantenimientoProveedor mp = new MantenimientoProveedor();
            Proveedores proveedores = new Proveedores
            {
                Id = int.Parse(collection["Id"].ToString()),
                Proveedor = collection["Proveedor"].ToString(),
                Contacto = collection["Contacto"].ToString(),




            };
            mp.Modificar(proveedores);
            return RedirectToAction("Index");
        }
    }
}