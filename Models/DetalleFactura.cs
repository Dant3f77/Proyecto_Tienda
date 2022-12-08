using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_Tienda.Models
{
    public class DetalleFactura
    {
        public int Id { get; set; }
        public int IdDetalle { get; set; }
        public float Precio { get; set; }
        public int Cantidad { get; set; }
        public int IdProducto { get; set; }
        public int IdFactura { get; set; }
        
    }
}