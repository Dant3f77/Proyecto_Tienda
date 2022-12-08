using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_Tienda.Models
{
    public class Abastecimiento
    {
        public int Id { get; set; }
        public int IdSucursalEnv { get; set; }
        public int IdSucursalRec { get; set; }
        public int IdProducto { get; set; }
        public DateTime Fecha { get; set; }
        public int IdUser { get; set; }
    }
}