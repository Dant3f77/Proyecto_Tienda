using Proyecto_Tienda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_Tienda.Controllers
{
    public class FacturaController : Controller
    {
        MantenimientoCliente mc = null;
        MantenimientoTienda mt = null;
        MantenimientoUsuario mu = null;
        ManteniemientoProducto mp = null;
        MantenimientoDetalleFactura mdf = null;

        

        // GET: Factura
        public ActionResult Index()
        {
            mc = new MantenimientoCliente();
            ViewBag.clientes = mc.RecuperarTodos();

            mt = new MantenimientoTienda();
            ViewBag.sucursales = mt.RecuperarTodos();

            mu = new MantenimientoUsuario();
            ViewBag.usuario = mu.RecuperarTodos();

            mp = new ManteniemientoProducto();
            ViewBag.producto = mp.RecuperarTodos();

            MantenimientoFactura mf = new MantenimientoFactura();
            return View(mf.RecuperarTodos());
        }

        public ActionResult Creacion() {
            mc = new MantenimientoCliente();
            ViewBag.clientes = mc.RecuperarTodos();

            mt = new MantenimientoTienda();
            ViewBag.sucursales = mt.RecuperarTodos();

            mu = new MantenimientoUsuario();
            ViewBag.usuario = mu.RecuperarTodos();

            mp = new ManteniemientoProducto();
            ViewBag.producto = mp.RecuperarTodos();
            ViewBag.modal = false;
            return View(); 
        }

        [HttpPost]
        public ActionResult Creacion(FormCollection collection)
        {
            mp = new ManteniemientoProducto();
            string date = DateTime.Now.ToString();
            Random rnd = new Random();
            String numFactura =  rnd.Next().ToString();

        MantenimientoFactura mf = new MantenimientoFactura();
            Factura factura = new Factura
            {
                NumFactura = numFactura,
                IdCliente = int.Parse(collection["IdCliente"]),
                Fecha = DateTime.Parse(date),            
                TipoPago = collection["TipoPago"],
                TipoFactura = collection["TipoFactura"],
                IdVendedor = int.Parse(collection["IdVendedor"]),
                IdSucursal = int.Parse(collection["IdSucursal"]),
            };
            mf.Alta(factura);

            factura = new Factura();
            factura = mf.RecuperarByNum(numFactura);

            int fila = int.Parse(collection["fila"]);
            MantenimientoDetalleFactura mdf = new MantenimientoDetalleFactura();

            for (int i = 1; i <= fila; i++)
            {
                DetalleFactura detalle = new DetalleFactura
                {
                    Precio = float.Parse(collection[i+"5"]),
                    Cantidad = int.Parse(collection[i+"2"]),
                    IdProducto = int.Parse(collection[i+"3"]),
                    IdFactura = factura.IdFactura,

                };
                mdf.Alta(detalle);

                Producto prodto = mp.Recuperar(detalle.IdProducto);

                prodto.Stock -= detalle.Cantidad;

                mp.Modificar(prodto);

            }
            ViewBag.modal = true;
            ViewBag.idFactura = factura.IdFactura;

            
            return View();
        }

        public ActionResult Baja(int idFactura)
        {
            MantenimientoFactura mf = new MantenimientoFactura();
            mf.Borrar(idFactura);
            return RedirectToAction("Index");
        }

        public ActionResult Modificacion(int idFactura)
        {
            MantenimientoFactura mf = new MantenimientoFactura();
            Factura factura = mf.Recuperar(idFactura);
            return View(factura);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Modificacion(FormCollection collection)
        {
            MantenimientoFactura mf = new MantenimientoFactura();
            Factura factura = new Factura
            {  
                IdCliente = int.Parse(collection["IdCliente"].ToString()),
                Fecha = DateTime.Parse(collection["Fecha"]),
                TipoPago = collection["TipoPago"].ToString(),
                TipoFactura = collection["TipoFactura"].ToString(),
                IdVendedor= int.Parse(collection["IdVendedor"].ToString()),
                IdSucursal = int.Parse(collection["IdSucursal"].ToString()),

              };
            mf.Modificar(factura);
            return RedirectToAction("Index");
        }

        [ValidateInput(false)]
        public ActionResult Details(int idFactura)
        {
            mc = new MantenimientoCliente();
            ViewBag.clientes = mc.RecuperarTodos();

            mt = new MantenimientoTienda();
            ViewBag.sucursales = mt.RecuperarTodos();

            mu = new MantenimientoUsuario();
            ViewBag.usuario = mu.RecuperarTodos();

            mp = new ManteniemientoProducto();
            ViewBag.producto = mp.RecuperarTodos();

            MantenimientoFactura mf = new MantenimientoFactura();
            mdf = new MantenimientoDetalleFactura();
            List<DetalleFactura> detalles = mdf.RecuperarTodosByFactura(idFactura);
            ViewBag.itemsFactura = detalles;
            ViewBag.total = GetTotal(detalles);
            Factura factura = mf.Recuperar(idFactura);
            ViewBag.factura = factura;
            
            return View(factura);
        }

        public float GetTotal(List<DetalleFactura> detalles)
        {
            float total = 0;
            foreach (DetalleFactura detalle in detalles)
            {
                total += (detalle.Cantidad * detalle.Precio);
            }
            return total;
        }
      
        
    }
}