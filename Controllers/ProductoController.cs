using Proyecto_Tienda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_Tienda.Controllers
{
    public class ProductoController : Controller
    {
        MantenimientoTienda mt = null;     
        MantenimientoProveedor mpr = null;

        // GET: Producto
        public ActionResult Index()
        {
            ManteniemientoProducto mp = new ManteniemientoProducto();
            return View(mp.RecuperarTodos());
        }

        public ActionResult Alta()
        {
            ManteniemientoProducto mp = new ManteniemientoProducto();
            ViewBag.productos = mp.RecuperarTodos();
            mt = new MantenimientoTienda();
            ViewBag.sucursales = mt.RecuperarTodos();
            mpr = new MantenimientoProveedor();
            ViewBag.Proveedor = mpr.RecuperarTodos();
            return View();
        }

        [HttpPost]
        public ActionResult Alta(FormCollection collection)
        {
            ManteniemientoProducto mp = new ManteniemientoProducto();
            Producto producto = new Producto
            {
                // Id,Marca,Codigo,Descripcion,PrecioVenta,PrecioCosto,Stock,IdTienda,IdProveedor

                
                Marca = collection["Marca"],
                Codigo = collection["Codigo"],
                Descripcion = collection["Descripcion"],
                PrecioVenta = float.Parse(collection["PrecioVenta"]),
                PrecioCosto = float.Parse(collection["PrecioCosto"]),
                Stock = int.Parse(collection["Stock"]),
                IdTienda = int.Parse(collection["IdTienda"]),
                IdProveedor = int.Parse(collection["IdProveedor"]),


            };            
            mp.Alta(producto);
            return RedirectToAction("Alta");
        }

        public ActionResult Baja(int id)
        {
            ManteniemientoProducto mp = new ManteniemientoProducto();
            mp.Borrar(id);
            return RedirectToAction("Index");
        }

        public ActionResult Modificacion(int id)
        {
            ManteniemientoProducto mp = new ManteniemientoProducto();
            Producto producto = mp.Recuperar(id);
            return View(producto);
        }

        [HttpPost]
        public ActionResult Modificacion(FormCollection collection)
        {
            ManteniemientoProducto mp = new ManteniemientoProducto();
            Producto producto = new Producto
            {
               
                
                Id = int.Parse(collection["Id"].ToString()),
                Marca = collection["Marca"].ToString(),
                Codigo = collection["Codigo"].ToString(),
                Descripcion = collection["Descripcion"].ToString(),
                PrecioVenta = float.Parse(collection["PrecioVenta"].ToString()),              
                PrecioCosto = float.Parse(collection["PrecioCosto"].ToString()),
                Stock = int.Parse(collection["Stock"].ToString()),
                IdTienda = int.Parse(collection["IdTienda"].ToString()),
                IdProveedor = int.Parse(collection["IdProveedor"].ToString())

            };
            mp.Modificar(producto);
            return RedirectToAction("Index");
        }
    }
}