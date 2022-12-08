using Proyecto_Tienda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_Tienda.Controllers
{
    public class ReporteController : Controller
    {
        // GET: Reporte
        public ActionResult Index()
        {
            MantenimientoReporte mr = new MantenimientoReporte();
            return View(mr.RecuperarTodos());
        }



        public ActionResult Alta()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Alta(FormCollection collection)
        {
            MantenimientoReporte mr = new MantenimientoReporte();
            Reporte reporte = new Reporte
            {
                Id = int.Parse(collection["Id"]),
                IdSucursal = int.Parse(collection["IdSucursal"]),
                Fecha = DateTime.Parse( collection["Fecha"]),
                Memo = collection["Memo"],
                Total = float.Parse(collection["Total"]),
                
            };

            mr.Alta(reporte);
            return RedirectToAction("Index");
        }

        public ActionResult Baja(int id)
        {
            MantenimientoReporte mr = new MantenimientoReporte();
            mr.Borrar(id);
            return RedirectToAction("Index");
        }

        public ActionResult Modificacion(int id)
        {
            MantenimientoReporte mr = new MantenimientoReporte();
            Reporte reporte = mr.Recuperar(id);
            return View(reporte);
        }

        [HttpPost]
        public ActionResult Modificacion(FormCollection collection)
        {
            MantenimientoReporte mr = new MantenimientoReporte();
            Reporte reporte = new Reporte
            {


                Id = int.Parse(collection["Id"].ToString()),
                IdSucursal = int.Parse(collection["IdSucursal"].ToString()),
                Fecha = DateTime.Parse(collection["Fecha"].ToString()),
                Memo = collection["Memo"].ToString(),
                Total = float.Parse(collection["Total"].ToString()),

            };
            mr.Modificar(reporte);
            return RedirectToAction("Index");
        }
    }
}