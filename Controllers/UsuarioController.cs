using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto_Tienda.Models;

namespace Proyecto_Tienda.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario



        public ActionResult Index()
        {
            MantenimientoUsuario mu = new MantenimientoUsuario();
            return View(mu.RecuperarTodos());
        }

        public ActionResult Administrar()
        {
            MantenimientoUsuario mu = new MantenimientoUsuario();
            return View(mu.RecuperarTodos());
        }

        public ActionResult Alta()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Alta(FormCollection collection)
        {
            MantenimientoUsuario mu = new MantenimientoUsuario();
            Usuario usuario = new Usuario
            {
                ///Id,Usuario,Contraseña,IdArea,IdTienda  @Id,@Usuario,@Contraseña,@IdArea,@IdTienda
                User = collection["Usuario"],
                Contraseña = collection["Pass"],
                IdArea = int.Parse(collection["IdArea"]),
                IdTienda = int.Parse(collection["IdTienda"]),
            };
            mu.Alta(usuario);
            return RedirectToAction("Index");
        }

        public ActionResult Baja(int id)
        {
            MantenimientoUsuario mu = new MantenimientoUsuario();
            mu.Borrar(id);
            return RedirectToAction("Index");
        }

        public ActionResult Modificacion(int id)
        {
            MantenimientoUsuario mu = new MantenimientoUsuario();
            Usuario usuario = mu.Recuperar(id);
            return View(usuario);
        }

        [HttpPost]
        public ActionResult Modificacion(FormCollection collection)
        {
            MantenimientoUsuario mu = new MantenimientoUsuario();
            Usuario usuario = new Usuario
            {
                Id = int.Parse(collection["Id"].ToString()),
                User = collection["Usuario"].ToString(),
                Contraseña = collection["Contraseña"].ToString(),
                IdArea = int.Parse(collection["IdArea"].ToString()),
                IdTienda = int.Parse(collection["IdTienda"].ToString()),

               

            };
            mu.Modificar(usuario);
            return RedirectToAction("Index");
        }
    }
}