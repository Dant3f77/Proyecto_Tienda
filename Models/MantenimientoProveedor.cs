using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Proyecto_Tienda.Models
{
    public class MantenimientoProveedor
    {

        private SqlConnection con;

        private void Conectar()
        {
            string constr = ConfigurationManager.ConnectionStrings["administracion"].ToString();
            con = new SqlConnection(constr);
        }

        public int Alta(Proveedores proveedor)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("insert into Proveedores(Proveedor,Contacto) values (@Proveedor,@Contacto)", con);
            ///Id,Proveedor,Contacto  @Id,@Proveedor,@Contacto
            
            comando.Parameters.Add("@Proveedor", SqlDbType.VarChar);
            comando.Parameters.Add("@Contacto", SqlDbType.VarChar);


           
            comando.Parameters["@Proveedor"].Value = proveedor.Proveedor;
            comando.Parameters["@Contacto"].Value = proveedor.Contacto;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }


        public List<Proveedores> RecuperarTodos()
        {
            Conectar();
            List<Proveedores> proveedores = new List<Proveedores>();

            SqlCommand com = new SqlCommand("select Id,Proveedor,Contacto from Proveedores", con);
            con.Open();
            SqlDataReader registros = com.ExecuteReader();
            while (registros.Read())
            {
                Proveedores proveedor = new Proveedores
                {
                     //Id,Proveedor,Contacto  @Id,@Proveedor,@Contacto
                    Id = int.Parse(registros["Id"].ToString()),
                    Proveedor = registros["Proveedor"].ToString(),
                    Contacto = registros["Contacto"].ToString(),

                };
                proveedores.Add(proveedor);
            }
            con.Close();
            return proveedores;
        }


        public Proveedores Recuperar(int Id)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("select Id,Proveedor,Contacto from Proveedores where Id=@Id", con);
            comando.Parameters.Add("@Id", SqlDbType.Int);
            comando.Parameters["@Id"].Value = Id;
            con.Open();
            SqlDataReader registros = comando.ExecuteReader();
            Proveedores proveedores = new Proveedores();
            if (registros.Read())
            {

                proveedores.Id = int.Parse(registros["Id"].ToString());
                proveedores.Proveedor = registros["Proveedor"].ToString();
                proveedores.Contacto = registros["Contacto"].ToString();

            }
            con.Close();
            return proveedores;
        }

        public int Modificar(Proveedores proveedores )
        {
            Conectar();
            SqlCommand comando = new SqlCommand("update Proveedores set Proveedor=@Proveedor,Contacto=@Contacto where Id=@id", con);


            comando.Parameters.Add("@Id", SqlDbType.Int);
            comando.Parameters["@Id"].Value = proveedores.Id;
            comando.Parameters.Add("@Proveedor", SqlDbType.VarChar);
            comando.Parameters["@Proveedor"].Value = proveedores.Proveedor;
            comando.Parameters.Add("@Contacto", SqlDbType.VarChar);
            comando.Parameters["@Contacto"].Value = proveedores.Contacto;


            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public int Borrar(int Id)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("delete from Proveedores where Id=@Id", con);
            comando.Parameters.Add("@Id", SqlDbType.Int);
            comando.Parameters["@Id"].Value = Id;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
}