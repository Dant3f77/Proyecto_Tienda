using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Proyecto_Tienda.Models
{
    public class MantenimientoDetalleFactura
    {

        private SqlConnection con;

        private void Conectar()
        {
            string constr = ConfigurationManager.ConnectionStrings["administracion"].ToString();
            con = new SqlConnection(constr);
        }

        public int Alta(DetalleFactura detalle)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("insert into DetalleFactura(Precio,Cantidad,IdProducto,IdFactura) values (@Precio,@Cantidad,@IdProducto,@IdFactura)", con);
            
            //Id,Precio,Cantidad,IdProducto,IdFactura   @Id,@Precio,@Cantidad,@IdProducto,@IdFactura
            comando.Parameters.Add("@Id", SqlDbType.Int);
            comando.Parameters.Add("@IdDetalle", SqlDbType.Int);
            comando.Parameters.Add("@Precio", SqlDbType.Float);            
            comando.Parameters.Add("@Cantidad", SqlDbType.Int);
            comando.Parameters.Add("@IdProducto", SqlDbType.Int);
            comando.Parameters.Add("@IdFactura", SqlDbType.Int);



            comando.Parameters["@Id"].Value = detalle.Id;
            comando.Parameters["@IdDetalle"].Value = detalle.Id;
            comando.Parameters["@Precio"].Value = detalle.Precio;
            comando.Parameters["@Cantidad"].Value = detalle.Cantidad;
            comando.Parameters["@IdProducto"].Value = detalle.IdProducto;
            comando.Parameters["@IdFactura"].Value = detalle.IdFactura;
            
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }


        public List<DetalleFactura> RecuperarTodos()
        {
            Conectar();
            List<DetalleFactura> detalle = new List<DetalleFactura>();

            SqlCommand com = new SqlCommand("select Id,IdDetalle,Precio,Cantidad,IdProducto,IdFactura from DetalleFactura", con);
            con.Open();
            SqlDataReader registros = com.ExecuteReader();
            while (registros.Read())
            {
                DetalleFactura detalles = new DetalleFactura
                {
                    //Id,Precio,Cantidad,IdProducto,IdFactura 
                    Id = int.Parse(registros["Id"].ToString()),
                    IdDetalle = int.Parse(registros["IdDetalle"].ToString()),
                    Precio = float.Parse(registros["Precio"].ToString()),
                    Cantidad = int.Parse(registros["Cantidad"].ToString()),
                    IdProducto = int.Parse(registros["IdProducto"].ToString()),
                    IdFactura = int.Parse(registros["IdDetalle"].ToString()),
                    


                };
                detalle.Add(detalles);
            }
            con.Close();
            return detalle;
        }

        public List<DetalleFactura> RecuperarTodosByFactura(int idFactura)
        {
            Conectar();
            List<DetalleFactura> detalle = new List<DetalleFactura>();

            SqlCommand com = new SqlCommand("select Id,IdDetalle,Precio,Cantidad,IdProducto,IdFactura from DetalleFactura where IdFactura=@Id", con);
            com.Parameters.Add("@Id", SqlDbType.Int);
            com.Parameters["@Id"].Value = idFactura;
            con.Open();
            SqlDataReader registros = com.ExecuteReader();
            while (registros.Read())
            {
                DetalleFactura detalles = new DetalleFactura
                {
                    //Id,Precio,Cantidad,IdProducto,IdFactura 
                    Id = int.Parse(registros["Id"].ToString()),                   
                    Precio = float.Parse(registros["Precio"].ToString()),
                    Cantidad = int.Parse(registros["Cantidad"].ToString()),
                    IdProducto = int.Parse(registros["IdProducto"].ToString()),
                    IdFactura = int.Parse(registros["IdFactura"].ToString()),



                };
                detalle.Add(detalles);
            }
            con.Close();
            return detalle;
        }


        public DetalleFactura Recuperar(int Id)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("select Id,IdDetalle,Precio,Cantidad,IdProducto,IdFactura from DetalleFactura where Id=@Id", con);
            comando.Parameters.Add("@Id", SqlDbType.Int);
            comando.Parameters["@Id"].Value = Id;
            con.Open();
            SqlDataReader registros = comando.ExecuteReader();
            DetalleFactura detalles = new DetalleFactura();
            if (registros.Read())
            {
                //Id,IdDetalle,Precio,Cantidad,IdProducto,IdFactura
                detalles.Id = int.Parse(registros["Id"].ToString());
                detalles.IdDetalle = int.Parse(registros["IdDetalle"].ToString());
                detalles.Precio = float.Parse(registros["Precio"].ToString());
                detalles.Cantidad = int.Parse(registros["Cantidad"].ToString());
                detalles.IdProducto = int.Parse(registros["IdProducto"].ToString());
                detalles.IdFactura = int.Parse(registros["IdFactura"].ToString());

         }
            con.Close();
            return detalles;
        }

        public int Modificar(DetalleFactura detalle)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("update DetalleFactura set Id=@Id,IdDetalle=@IdDetalle,Precio=@Precio,Cantidad=@Cantidad,IdProducto=@IdProducto,IdFactura=@IdFactura where Id=@id", con);
            comando.Parameters.Add("@Id", SqlDbType.Int);
            comando.Parameters.Add("@IdDetalle", SqlDbType.Int);
            comando.Parameters.Add("@Precio", SqlDbType.Float);
            comando.Parameters.Add("@Cantidad", SqlDbType.Int);
            comando.Parameters.Add("@Idproducto", SqlDbType.Int);
            comando.Parameters.Add("@IdFactura", SqlDbType.Int);         
            
            comando.Parameters["@Id"].Value = detalle.Id;
            comando.Parameters["@IdDetalle"].Value = detalle.IdDetalle;
            comando.Parameters["@Precio"].Value = detalle.Precio;
            comando.Parameters["@Cantidad"].Value = detalle.Cantidad;
            comando.Parameters["@IdProducto"].Value = detalle.IdProducto;
            comando.Parameters["@IdFactura"].Value = detalle.IdFactura;
                        
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public int Borrar(int Id)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("delete from DetalleFactura where Id=@Id", con);
            comando.Parameters.Add("@Id", SqlDbType.Int);
            comando.Parameters["@Id"].Value = Id;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
}