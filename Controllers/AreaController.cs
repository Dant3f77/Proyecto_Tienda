using Proyecto_Tienda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Proyecto_Tienda.Controllers
{
    public class AreaController : Controller
    {
        // GET: Area
        public ActionResult Index()
        {
            MantenimientoArea ma = new MantenimientoArea();
            return View(ma.RecuperarTodos());
        }

      

        public ActionResult Alta()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Alta(FormCollection collection)
        {
            MantenimientoArea ma = new MantenimientoArea();
            Area area = new Area
            {                               
                AreaTrabajo = collection["AreaTrabajo"],                
            };
            ma.Alta(area);
            return RedirectToAction("Index");
        }

        public ActionResult Baja(int id)
        {
            MantenimientoArea ma = new MantenimientoArea();
            ma.Borrar(id);
            return RedirectToAction("Index");
        }

        public ActionResult Modificacion(int id)
        {
            MantenimientoArea ma = new MantenimientoArea();
            Area area = ma.Recuperar(id);
            return View(area);
        }

        [HttpPost]
        public ActionResult Modificacion(FormCollection collection)
        {
            MantenimientoArea ma = new MantenimientoArea();
            Area area = new Area
            {
                Id = int.Parse(collection["Id"].ToString()),
                AreaTrabajo = collection["AreaTrabajo"].ToString(),
                



            };
            ma.Modificar(area);
            return RedirectToAction("Index");
        }
    }
}