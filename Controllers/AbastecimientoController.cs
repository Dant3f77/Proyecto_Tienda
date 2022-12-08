using Proyecto_Tienda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_Tienda.Controllers
{
    public class AbastecimientoController : Controller
    {
        MantenimientoTienda mt = null;
        MantenimientoUsuario mu = null;
        ManteniemientoProducto mp = null;
        // GET: Abastecimiento
        // GET: Factura
        public ActionResult Index()
        {
            mantenimientoAbastecimiento ma = new mantenimientoAbastecimiento();
            return View(ma.RecuperarTodos());
        }



        public ActionResult Alta()
        {
            mt = new MantenimientoTienda();
            ViewBag.sucursales = mt.RecuperarTodos();

            mu = new MantenimientoUsuario();
            ViewBag.usuario = mu.RecuperarTodos();

            mp = new ManteniemientoProducto();
            ViewBag.producto = mp.RecuperarTodos();

            mantenimientoAbastecimiento ma = new mantenimientoAbastecimiento();
            return View(ma.RecuperarTodos());
        }

        [HttpPost]
        public ActionResult Alta(FormCollection collection)
        {
            mantenimientoAbastecimiento ma = new mantenimientoAbastecimiento();
            Abastecimiento abastecimiento = new Abastecimiento
            {
                //Id,IdSucursalEnv,IdSucursalRec,IdProducto,Fecha,IdUser  @Id,@IdSucursalEnv,@IdSucursalRec,@IdProducto,@Fecha,@IdUser                
                IdSucursalEnv = int.Parse(collection["IdSucursalEnv"]),
                IdSucursalRec = int.Parse(collection["IdSucursalRec"]),
                IdProducto = int.Parse(collection["IdProducto"]),
                Fecha = DateTime.Parse(collection["Fecha"]),
                IdUser = int.Parse(collection["IdUser"]),
            };

            ma.Alta(abastecimiento);
            return RedirectToAction("Alta");
        }

        public ActionResult Baja(int id)
        {
            mantenimientoAbastecimiento ma = new mantenimientoAbastecimiento();

            ma.Borrar(id);
            return RedirectToAction("Index");
        }

        public ActionResult Modificacion(int id)
        {
            mantenimientoAbastecimiento ma = new mantenimientoAbastecimiento();
            Abastecimiento abastecimiento = ma.Recuperar(id);
            return View(abastecimiento);
        }

        [HttpPost]
        public ActionResult Modificacion(FormCollection collection)
        {
            mantenimientoAbastecimiento ma = new mantenimientoAbastecimiento();
            Abastecimiento abastecimiento = new Abastecimiento
            {
                //Id,IdSucursalEnv,IdSucursalRec,IdProducto,Fecha,IdUser  @Id,@IdSucursalEnv,@IdSucursalRec,@IdProducto,@Fecha,@IdUser

                Id = int.Parse(collection["Id"].ToString()),
                IdSucursalEnv = int.Parse(collection["IdSucursalEnv"].ToString()),
                IdSucursalRec = int.Parse(collection["IdSucursalRec"].ToString()),
                IdProducto = int.Parse(collection["IdProducto"].ToString()),
                Fecha = DateTime.Parse(collection["Fecha"].ToString()),
                IdUser = int.Parse(collection["IdUserl"].ToString()),

            };
            ma.Modificar(abastecimiento);
            return RedirectToAction("Index");
        }
    }
}