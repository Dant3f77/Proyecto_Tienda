using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_Tienda.Models
{
    public class Producto
    {

        public int Id { get; set; }
        public string Marca{ get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public float PrecioVenta { get; set; }
        public float PrecioCosto { get; set; }
        public int Stock { get; set; }
        public int IdTienda { get; set; }
        public int IdProveedor { get; set; }

    }
}