using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace Proyecto_Tienda.Models
{
    public class ManteniemientoProducto
    {
        //Id,Marca,Codigo,Descripcion,PrecioVenta,PrecioCosto,Stock,IdTienda,IdProveedor @Id,@Marca,@Codigo,@Descripcion,@PrecioVenta,@PrecioCosto,@Stock,@IdTienda,@IdProveedor

        private SqlConnection con;

        private void Conectar()
        {
            string constr = ConfigurationManager.ConnectionStrings["administracion"].ToString();
            con = new SqlConnection(constr);
        }

        public int Alta(Producto producto)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("insert into Producto(Marca,Codigo,Descripcion,PrecioVenta,PrecioCosto,Stock,IdTienda,IdProveedor) values (@Marca,@Codigo,@Descripcion,@PrecioVenta,@PrecioCosto,@Stock,@IdTienda,@IdProveedor)", con);
            //Id,Marca,Codigo,Descripcion,PrecioVenta,PrecioCosto,Stock,IdTienda,IdProveedor @Id,@Marca,@Codigo,@Descripcion,@PrecioVenta,@PrecioCosto,@Stock,@IdTienda,@IdProveedor
            
            comando.Parameters.Add("@Marca", SqlDbType.VarChar);
            comando.Parameters.Add("@Codigo", SqlDbType.VarChar);
            comando.Parameters.Add("@Descripcion", SqlDbType.VarChar);
            comando.Parameters.Add("@PrecioVenta", SqlDbType.Float);
            comando.Parameters.Add("@PrecioCosto", SqlDbType.Float);
            comando.Parameters.Add("@Stock", SqlDbType.Int);
            comando.Parameters.Add("@IdTienda", SqlDbType.Int);
            comando.Parameters.Add("@IdProveedor", SqlDbType.Int);



            
            comando.Parameters["@Marca"].Value = producto.Marca;
            comando.Parameters["@Codigo"].Value = producto.Codigo;
            comando.Parameters["@Descripcion"].Value = producto.Descripcion;
            comando.Parameters["@PrecioVenta"].Value = producto.PrecioVenta;
            comando.Parameters["@PrecioCosto"].Value = producto.PrecioCosto;
            comando.Parameters["@Stock"].Value = producto.Stock;
            comando.Parameters["@IdTienda"].Value = producto.IdTienda;
            comando.Parameters["@IdProveedor"].Value = producto.IdProveedor;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }


        public List<Producto> RecuperarTodos()
        {
            Conectar();
            List<Producto> producto = new List<Producto>();

            SqlCommand com = new SqlCommand("select Id,Marca,Codigo,Descripcion,PrecioVenta,PrecioCosto,Stock,IdTienda,IdProveedor from Producto", con);
            con.Open();
            SqlDataReader registros = com.ExecuteReader();
            while (registros.Read())
            {
                Producto productos = new Producto
                {
                    //Id,Marca,Codigo,Descripcion,PrecioVenta,PrecioCosto,Stock,IdTienda,IdProveedor
                    Id = int.Parse(registros["Id"].ToString()),
                    Marca = registros["Marca"].ToString(),
                    Codigo = registros["Codigo"].ToString(),
                    Descripcion= registros["Descripcion"].ToString(),
                    PrecioVenta = float.Parse(registros["PrecioVenta"].ToString()),
                    PrecioCosto = float.Parse(registros["PrecioCosto"].ToString()),
                    Stock = int.Parse(registros["Stock"].ToString()),
                    IdTienda = int.Parse(registros["IdTienda"].ToString()),
                    IdProveedor = int.Parse(registros["IdProveedor"].ToString()),


                };
                producto.Add(productos);
            }
            con.Close();
            return producto;
        }


        public Producto Recuperar(int Id)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("select Id,Marca,Codigo,Descripcion,PrecioVenta,PrecioCosto,Stock,IdTienda,IdProveedor from Producto where Id=@Id", con);
            comando.Parameters.Add("@Id", SqlDbType.Int);
            comando.Parameters["@Id"].Value = Id;
            con.Open();
            SqlDataReader registros = comando.ExecuteReader();
            Producto producto = new Producto();
            if (registros.Read())
            {
                //Id,Marca,Codigo,Descripcion,PrecioVenta,PrecioCosto,Stock,IdTienda,IdProveedor @Id,@Marca,@Codigo,@Descripcion,@PrecioVenta,@PrecioCosto,@Stock,@IdTienda,@IdProveedor
              

                producto.Id = int.Parse(registros["Id"].ToString());
                producto.Marca = registros["Marca"].ToString();
                producto.Codigo = registros["Codigo"].ToString();
                producto.Descripcion = registros["Descripcion"].ToString();
                producto.PrecioVenta = float.Parse(registros["PrecioVenta"].ToString());
                producto.PrecioCosto = float.Parse(registros["PrecioCosto"].ToString());
                producto.Stock = int.Parse(registros["Stock"].ToString());
                producto.IdTienda = int.Parse(registros["IdTienda"].ToString());
                producto.IdProveedor = int.Parse(registros["IdProveedor"].ToString());



            }
            con.Close();
            return producto;
        }

        public int Modificar(Producto producto)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("update Producto set Marca=@Marca,Codigo=@Codigo,Descripcion=@Descripcion,PrecioVenta=@PrecioVenta,PrecioCosto=@PrecioCosto,Stock=@Stock,IdTienda=@IdTienda,IdProveedor=@IdProveedor where Id=@id", con);
            //Id,Marca,Codigo,Descripcion,PrecioVenta,PrecioCosto,Stock,IdTienda,IdProveedor @Id,@Marca,@Codigo,@Descripcion,@PrecioVenta,@PrecioCosto,@Stock,@IdTienda,@IdProveedor

            
            comando.Parameters.Add("@Id", SqlDbType.Int);
            comando.Parameters.Add("@Marca", SqlDbType.VarChar);
            comando.Parameters.Add("@Codigo", SqlDbType.VarChar);
            comando.Parameters.Add("@Descripcion", SqlDbType.VarChar);
            comando.Parameters.Add("@PrecioVenta", SqlDbType.Float);
            comando.Parameters.Add("@PrecioCosto", SqlDbType.Float);
            comando.Parameters.Add("@Stock", SqlDbType.Int);
            comando.Parameters.Add("@IdTienda", SqlDbType.Int);
            comando.Parameters.Add("@IdProveedor", SqlDbType.Int);



            comando.Parameters["@Id"].Value = producto.Id;
            comando.Parameters["@Marca"].Value = producto.Marca;
            comando.Parameters["@Codigo"].Value = producto.Codigo;
            comando.Parameters["@Descripcion"].Value = producto.Descripcion;
            comando.Parameters["@PrecioVenta"].Value = producto.PrecioVenta;
            comando.Parameters["@PrecioCosto"].Value = producto.PrecioCosto;
            comando.Parameters["@Stock"].Value = producto.Stock;
            comando.Parameters["@IdTienda"].Value = producto.IdTienda;
            comando.Parameters["@IdProveedor"].Value = producto.IdProveedor;


            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public int Borrar(int Id)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("delete from Producto where Id=@Id", con);
            comando.Parameters.Add("@Id", SqlDbType.Int);
            comando.Parameters["@Id"].Value = Id;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
}