using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Proyecto_Tienda.Models
{
    public class MantenimientoReporte
    {

        private SqlConnection con;

        private void Conectar()
        {
            string constr = ConfigurationManager.ConnectionStrings["administracion"].ToString();
            con = new SqlConnection(constr);
        }

        public int Alta(Reporte reporte)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("insert into Reporte(Id,IdSucursal,Fecha,Memo,Total) values (@Id,@IdSucursal,@Fecha,@Memo,@Total)", con);
            //Id,IdSucursal,Fecha,Memo,Total @Id,@IdSucursal,@Fecha,@Memo,@Total
            comando.Parameters.Add("@Id", SqlDbType.Int);
            comando.Parameters.Add("@IdSucursal", SqlDbType.Int);
            comando.Parameters.Add("@Fecha", SqlDbType.Date);
            comando.Parameters.Add("@Memo", SqlDbType.VarChar);
            comando.Parameters.Add("@Total", SqlDbType.Float);


            comando.Parameters["@Id"].Value = reporte.Id;
            comando.Parameters["@IdSucursal"].Value = reporte.IdSucursal;
            comando.Parameters["@Fecha"].Value = reporte.Fecha;
            comando.Parameters["@Memo"].Value = reporte.Memo;
            comando.Parameters["@Total"].Value = reporte.Total;

            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }


        public List<Reporte> RecuperarTodos()
        {
            Conectar();
            List<Reporte> reportes = new List<Reporte>();

            SqlCommand com = new SqlCommand("select Id,IdSucursal,Fecha,Memo,Total from Reporte", con);
            con.Open();
            SqlDataReader registros = com.ExecuteReader();
            while (registros.Read())
            {
                Reporte reporte = new Reporte
                {
                    //Id,IdSucursal,Fecha,Memo,Total @Id,@IdSucursal,@Fecha,@Memo,@Total
                    Id = int.Parse(registros["Id"].ToString()),
                    IdSucursal = int.Parse(registros["IdSucursal"].ToString()),
                    Fecha = DateTime.Parse(registros["Fecha"].ToString()),
                    Memo = registros["Memo"].ToString(),
                    Total = float.Parse(registros["Total"].ToString()),
                    

                };
                reportes.Add(reporte);
            }
            con.Close();
            return reportes;
        }


        public Reporte Recuperar(int id)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("select Id,IdSucursal,Fecha,Memo,Total from Reporte where Id=@Id", con);
            comando.Parameters.Add("@Id", SqlDbType.Int);
            comando.Parameters["@Id"].Value = id;
            con.Open();
            SqlDataReader registros = comando.ExecuteReader();
            Reporte reporte = new Reporte();
            if (registros.Read())
            {

                //Id,IdSucursal,Fecha,Memo,Total @Id,@IdSucursal,@Fecha,@Memo,@Total

                reporte.Id = int.Parse(registros["Id"].ToString());
                reporte.IdSucursal = int.Parse(registros["IdSucursal"].ToString());
                reporte.Fecha = DateTime.Parse(registros["Fecha"].ToString());
                reporte.Memo = registros["Memo"].ToString();
                reporte.Total = float.Parse(registros["Total"].ToString());             

            }
            con.Close();
            return reporte;
        }

        public int Modificar(Reporte reporte)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("update Factura set Id=@Id,IdSucursal=@IdSucursal,Fecha=@Fecha,Memo=@Memo,Total=@Total where Id=@id", con);

            //Id,IdSucursal,Fecha,Memo,Total @Id,@IdSucursal,@Fecha,@Memo,@Total

            comando.Parameters.Add("@Id", SqlDbType.Int);
            comando.Parameters.Add("@IdSucursal", SqlDbType.Int);
            comando.Parameters.Add("@Fecha", SqlDbType.Date);
            comando.Parameters.Add("@Memo", SqlDbType.VarChar);
            comando.Parameters.Add("@Total", SqlDbType.Float);


            comando.Parameters["@Id"].Value = reporte.Id;
            comando.Parameters["@IdSucursal"].Value = reporte.IdSucursal;
            comando.Parameters["@Fecha"].Value = reporte.Fecha;
            comando.Parameters["@Memo"].Value = reporte.Memo;
            comando.Parameters["@Total"].Value = reporte.Total;
            
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public int Borrar(int id)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("delete from Reporte where Id=@Id", con);
            comando.Parameters.Add("@IdFactura", SqlDbType.Int);
            comando.Parameters["@Id"].Value = id;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
}