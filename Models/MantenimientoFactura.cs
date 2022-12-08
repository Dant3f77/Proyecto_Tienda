using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Proyecto_Tienda.Models
{
    public class MantenimientoFactura
    {
      

        private SqlConnection con;

        private void Conectar()
        {
            string constr = ConfigurationManager.ConnectionStrings["administracion"].ToString();
            con = new SqlConnection(constr);
        }

        public int Alta(Factura factura)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("insert into Factura(IdCliente,Fecha,TipoPago,TipoFactura,IdVendedor,IdSucursal,NumFactura) values (@IdCliente,@Fecha,@TipoPago,@TipoFactura,@IdVendedor,@IdSucursal,@numFactura)", con);
            //IdFactura,IdCliente,Fecha,TipoPago,TipoFactura,IdVendedor,IdSucursal  @IdFactura,@IdCliente,@Fecha,@TipoPago,@TipoFactura,@IdVendedor,@IdSucursal
            comando.Parameters.Add("@numFactura", SqlDbType.VarChar);
            comando.Parameters.Add("@IdCliente", SqlDbType.Int);
            comando.Parameters.Add("@Fecha", SqlDbType.Date);
            comando.Parameters.Add("@TipoPago", SqlDbType.VarChar);
            comando.Parameters.Add("@TipoFactura", SqlDbType.VarChar);
            comando.Parameters.Add("@IdVendedor", SqlDbType.Int);
            comando.Parameters.Add("@IdSucursal", SqlDbType.Int);

            comando.Parameters["@numFactura"].Value = factura.NumFactura;
            comando.Parameters["@IdCliente"].Value = factura.IdCliente;
            comando.Parameters["@Fecha"].Value = factura.Fecha;
            comando.Parameters["@TipoPago"].Value = factura.TipoPago;
            comando.Parameters["@TipoFactura"].Value = factura.TipoFactura;
            comando.Parameters["@IdVendedor"].Value = factura.IdVendedor;
            comando.Parameters["@IdSucursal"].Value = factura.IdSucursal;

            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }


        public List<Factura> RecuperarTodos()
        {
            Conectar();
            List<Factura> facturas = new List<Factura>();

            SqlCommand com = new SqlCommand("select IdFactura,IdCliente,Fecha,TipoPago,TipoFactura,IdVendedor,IdSucursal from Factura", con);
            con.Open();
            SqlDataReader registros = com.ExecuteReader();
            while (registros.Read())
            {
               Factura factura= new Factura
                {
                    
                    IdFactura = int.Parse(registros["IdFactura"].ToString()),
                    IdCliente = int.Parse(registros["IdCliente"].ToString()),
                    Fecha= DateTime.Parse(registros["Fecha"].ToString()),
                    TipoPago = registros["TipoPago"].ToString(),
                    TipoFactura = registros["TipoFactura"].ToString(),
                    IdVendedor = int.Parse(registros["Idvendedor"].ToString()),    
                    IdSucursal = int.Parse(registros["IdSucursal"].ToString()),
                  
                };
                facturas.Add(factura);
            }
            con.Close();
            return facturas;
        }


        public Factura Recuperar(int idFactura)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("select IdFactura,IdCliente,Fecha,TipoPago,TipoFactura,IdVendedor,IdSucursal,NumFactura from Factura where IdFactura=@IdFactura", con);
            comando.Parameters.Add("@IdFactura", SqlDbType.Int);
            comando.Parameters["@IdFactura"].Value = idFactura;
            con.Open();
            SqlDataReader registros = comando.ExecuteReader();
            Factura factura= new Factura();
            if (registros.Read())
            {

                factura.IdFactura = int.Parse(registros["IdFactura"].ToString());
                factura.IdCliente = int.Parse(registros["IdCliente"].ToString());
                factura.Fecha = DateTime.Parse(registros["Fecha"].ToString());
                factura.TipoPago = registros["TipoPago"].ToString();
                factura.TipoFactura = registros["TipoFactura"].ToString();
                factura.IdVendedor = int.Parse(registros["IdVendedor"].ToString());
                factura.NumFactura = registros["NumFactura"].ToString();
                factura.IdSucursal = int.Parse(registros["IdSucursal"].ToString());



            }
            con.Close();
            return factura;
        }

        public Factura RecuperarByNum(string Factura)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("select IdFactura,IdCliente,Fecha,TipoPago,TipoFactura,IdVendedor,IdSucursal,NumFactura from Factura where NumFactura=@Factura", con);
            comando.Parameters.Add("@Factura", SqlDbType.VarChar);
            comando.Parameters["@Factura"].Value = Factura;
            con.Open();
            SqlDataReader registros = comando.ExecuteReader();
            Factura factura = new Factura();
            if (registros.Read())
            {
                factura.IdFactura = int.Parse(registros["IdFactura"].ToString());
                factura.IdCliente = int.Parse(registros["IdCliente"].ToString());
                factura.Fecha = DateTime.Parse(registros["Fecha"].ToString());
                factura.TipoPago = registros["TipoPago"].ToString();
                factura.TipoFactura = registros["TipoFactura"].ToString();
                factura.IdVendedor = int.Parse(registros["IdVendedor"].ToString());
                factura.NumFactura = registros["NumFactura"].ToString();



            }
            con.Close();
            return factura;
        }


        public int Modificar(Factura factura)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("update Factura set IdFactura=@IdFactura,IdCliente=@IdCliente,Fecha=@Fecha,TipoPago=@TipoPago,TipoFactura=@TipoFactura,IdVendedor=@IdVendedor,IdSucursal=@IdSucursal  where IdFactura=@idFactura", con);



            comando.Parameters.Add("@IdFactura", SqlDbType.Int);
            comando.Parameters.Add("@IdCliente", SqlDbType.Int);
            comando.Parameters.Add("@Fecha",SqlDbType.Date);
            comando.Parameters.Add("@TipoPago", SqlDbType.VarChar);
            comando.Parameters.Add("@TipoFactura", SqlDbType.VarChar);
            comando.Parameters.Add("@IdVendedor", SqlDbType.Int);
            comando.Parameters.Add("@IdSucursal", SqlDbType.Int);



            comando.Parameters["@IdFactura"].Value = factura.IdFactura;
            comando.Parameters["@IdCliente"].Value = factura.IdCliente;
            comando.Parameters["@TipoPago"].Value = factura.TipoPago;
            comando.Parameters["@Fecha"].Value = factura.Fecha;
            comando.Parameters["@TipoFactura"].Value = factura.TipoFactura;
            comando.Parameters["@IdVendedor"].Value = factura.IdVendedor;
            comando.Parameters["@IdSucursal"].Value = factura.IdSucursal;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public int Borrar(int IdFactura)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("delete from Factura where IdFactura=@IdFactura", con);
            comando.Parameters.Add("@IdFactura", SqlDbType.Int);
            comando.Parameters["@IdFactura"].Value = IdFactura;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
}