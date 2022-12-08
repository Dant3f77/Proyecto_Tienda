using Proyecto_Tienda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_Tienda.Controllers
{
    public class DetalleFacturaController : Controller
    {
        // GET: DetalleFactura
        public ActionResult Index()
        {
            MantenimientoDetalleFactura mdf = new MantenimientoDetalleFactura();
            return View(mdf.RecuperarTodos());
        }



        public ActionResult Alta()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Alta(FormCollection collection)
        {
            MantenimientoDetalleFactura mdf = new MantenimientoDetalleFactura();
            DetalleFactura detalle = new DetalleFactura
            {
                // Id,IdDetalle,Precio,Cantidad,IdProducto,IdFactura

                Id = int.Parse(collection["Id"]),
                IdDetalle = int.Parse(collection["IdDetalle"]),
                Precio = float.Parse(collection["Precio"]),
                Cantidad = int.Parse(collection["Cantidad"]),
                IdProducto = int.Parse(collection["IdProducto"]),
                IdFactura = int.Parse(collection["IdFactura"]),

            };
            mdf.Alta(detalle);
            return RedirectToAction("Index");
        }



        public ActionResult Baja(int id)
        {
            MantenimientoDetalleFactura mdf = new MantenimientoDetalleFactura();
            mdf.Borrar(id);
            return RedirectToAction("Index");
        }



        public ActionResult Modificacion(int id)
        {
            MantenimientoDetalleFactura mdf = new MantenimientoDetalleFactura();
            DetalleFactura detalle = mdf.Recuperar(id);
            return View(detalle);
        }



        [HttpPost]
        public ActionResult Modificacion(FormCollection collection)
        {
            MantenimientoDetalleFactura mdf = new MantenimientoDetalleFactura();
            DetalleFactura detalle = new DetalleFactura
            {
                // Id,IdDetalle,Precio,Cantidad,IdProducto,IdFactura


                Id = int.Parse(collection["Id"].ToString()),
                IdDetalle = int.Parse(collection["IdDetalle"].ToString()),
                Precio = float.Parse(collection["Precio"].ToString()),
                Cantidad = int.Parse(collection["Cantidad"].ToString()),
                IdProducto = int.Parse(collection["IdProducto"].ToString()),
                IdFactura = int.Parse(collection["IdFactura"].ToString()),

            };
            mdf.Modificar(detalle);
            return RedirectToAction("Index");
        }
    }
}