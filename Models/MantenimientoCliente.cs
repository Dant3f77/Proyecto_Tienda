using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Proyecto_Tienda.Models
{
    public class MantenimientoCliente
    {

        private SqlConnection con;

        private void Conectar()
        {
            string constr = ConfigurationManager.ConnectionStrings["administracion"].ToString();
            con = new SqlConnection(constr);
        }

        public int Alta(Cliente client)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("insert into Cliente(Nombre,Direccion) values (@Nombre,@Direccion)", con);
            ///Id,Nombre,Direccion  @Id,@Nombre,@Direccion
            comando.Parameters.Add("@Nombre", SqlDbType.VarChar);
            comando.Parameters.Add("@Direccion", SqlDbType.VarChar);

            comando.Parameters["@Nombre"].Value = client.Nombre;
            comando.Parameters["@Direccion"].Value = client.Direccion;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }


        public List<Cliente> RecuperarTodos()
        {
            Conectar();
            List<Cliente> client = new List<Cliente>();

            SqlCommand com = new SqlCommand("select Id,Nombre,Direccion from Cliente", con);
            con.Open();
            SqlDataReader registros = com.ExecuteReader();
            while (registros.Read())
            {
               Cliente cliente = new Cliente
                {
                   
                    Id = int.Parse(registros["Id"].ToString()),
                    Nombre = registros["Nombre"].ToString(),
                    Direccion = registros["Direccion"].ToString(),

               };
                client.Add(cliente);
            }
            con.Close();
            return client;
        }


        public Cliente Recuperar(int Id)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("select Id,Nombre,Direccion from Cliente where Id=@Id", con);
            comando.Parameters.Add("@Id", SqlDbType.Int);
            comando.Parameters["@Id"].Value = Id;
            con.Open();
            SqlDataReader registros = comando.ExecuteReader();
            Cliente client = new Cliente();
            if (registros.Read())
            {

                client.Id= int.Parse(registros["Id"].ToString());
                client.Nombre = registros["Nombre"].ToString();
                client.Direccion = registros["Direccion"].ToString();

            }
            con.Close();
            return client;
        }

        public int Modificar(Cliente client)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("update Cliente set Id=@Id,Nombre=@Nombre,Direccion=@Direccion where Id=@id", con);


            comando.Parameters.Add("@Id", SqlDbType.Int);
            comando.Parameters["@Id"].Value = client.Id;
            comando.Parameters.Add("@Nombre", SqlDbType.VarChar);
            comando.Parameters["@Nombre"].Value = client.Nombre;
            comando.Parameters.Add("@Direccion", SqlDbType.VarChar);
            comando.Parameters["@Direccion"].Value = client.Direccion;

            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public int Borrar(int Id)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("delete from Cliente where Id=@Id", con);
            comando.Parameters.Add("@Id", SqlDbType.Int);
            comando.Parameters["@Id"].Value = Id;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
}