using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_Tienda.Models
{
    public class Reporte
    {
        public int Id{ get; set; }
        public int IdSucursal { get; set; }
        public DateTime Fecha { get; set; }
        public string Memo { get; set; }
        public float Total { get; set; }
    
    }
}