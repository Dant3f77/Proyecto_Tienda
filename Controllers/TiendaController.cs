using Proyecto_Tienda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Proyecto_Tienda.Controllers
{
    public class TiendaController : Controller
    {
        // GET: Tienda

        public ActionResult Index()
        {
            MantenimientoTienda mt = new MantenimientoTienda();
            return View(mt.RecuperarTodos());
        }

        public ActionResult Administrar()
        {
            MantenimientoTienda mt = new MantenimientoTienda();
            return View(mt.RecuperarTodos());
        }

        public ActionResult Alta()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Alta(FormCollection collection)
        {
            MantenimientoTienda mt = new MantenimientoTienda();
            Tienda tienda= new Tienda
            {
                ///Usuario,Contraseña,IdArea,IdTienda  @Usuario,@Contraseña,@IdArea,@IdTienda

                
                Sucursal = collection["Sucursal"],
                
            };
            mt.Alta(tienda);
            return RedirectToAction("Index");
        }

        public ActionResult Baja(int id)
        {
            MantenimientoTienda mt = new MantenimientoTienda();
            mt.Borrar(id);
            return RedirectToAction("Index");
        }

        public ActionResult Modificacion(int id)
        {
            MantenimientoTienda mt = new MantenimientoTienda();
            Tienda tienda = mt.Recuperar(id);
            return View(tienda);
        }

        [HttpPost]
        public ActionResult Modificacion(FormCollection collection)
        {
            MantenimientoTienda mt = new MantenimientoTienda();
            Tienda tienda = new Tienda
            {
                
                Sucursal = collection["Sucursal"].ToString(),
                
            };
            mt.Modificar(tienda);
            return RedirectToAction("Index");
        }
    }
}