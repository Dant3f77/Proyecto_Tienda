using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Proyecto_Tienda.Models
{
    public class MantenimientoTienda
    {
        private SqlConnection con;

        private void Conectar()
        {
            string constr = ConfigurationManager.ConnectionStrings["administracion"].ToString();
            con = new SqlConnection(constr);
        }

        public int Alta(Tienda tienda)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("insert into Tienda(Sucursal) values (@Sucursal)", con);
            ///Id,Sucursal,  @Id,@Sucursal
            comando.Parameters.Add("@Id", SqlDbType.Int);
            comando.Parameters.Add("@Sucursal", SqlDbType.VarChar);



            comando.Parameters["@Id"].Value = tienda.Id;
            comando.Parameters["@Sucursal"].Value = tienda.Sucursal;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }


        public List<Tienda> RecuperarTodos()
        {
            Conectar();
            List<Tienda> tiendas= new List<Tienda>();

            SqlCommand com = new SqlCommand("select Id, Sucursal from Tienda", con);
            con.Open();
            SqlDataReader registros = com.ExecuteReader();
            while (registros.Read())
            {
                Tienda tienda = new Tienda
                {
                    
                    Id = int.Parse(registros["Id"].ToString()),
                    Sucursal = registros["Sucursal"].ToString(),

                };
                tiendas.Add(tienda);
            }
            con.Close();
            return tiendas;
        }


        public Tienda Recuperar(int Id)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("select Sucursal from Tienda where Id=@Id", con);
            comando.Parameters.Add("@Id", SqlDbType.Int);
            comando.Parameters["@Id"].Value = Id;
            con.Open();
            SqlDataReader registros = comando.ExecuteReader();
            Tienda tienda = new Tienda();
            if (registros.Read())
            {

                tienda.Id = int.Parse(registros["Id"].ToString());
                tienda.Sucursal = registros["Sucursal"].ToString();

            }
            con.Close();
            return tienda;
        }

        public int Modificar(Tienda tienda)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("update Tienda set Sucursal=@Sucursal where Id=@id", con);


            comando.Parameters.Add("@Id", SqlDbType.Int);
            comando.Parameters["@Id"].Value = tienda.Id;
            comando.Parameters.Add("@Sucursal", SqlDbType.VarChar);
            comando.Parameters["@Sucursal"].Value = tienda.Sucursal;


            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public int Borrar(int Id)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("delete from Tienda where Id=@Id", con);
            comando.Parameters.Add("@Id", SqlDbType.Int);
            comando.Parameters["@Id"].Value = Id;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
}