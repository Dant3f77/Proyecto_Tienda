using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_Tienda.Models
{
    public class Factura
    {
        public int IdFactura { get; set; }
        public string NumFactura { get; set; }
        public int IdCliente { get; set; }
        public DateTime  Fecha { get; set; }
        public string TipoPago { get; set; }
        public string TipoFactura { get; set; }
        public int IdVendedor { get; set; }
        public int IdSucursal { get; set; }

    }
}