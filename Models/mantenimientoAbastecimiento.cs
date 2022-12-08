using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Proyecto_Tienda.Models
{
    public class mantenimientoAbastecimiento
    {
        private SqlConnection con;

        private void Conectar()
        {
            string constr = ConfigurationManager.ConnectionStrings["administracion"].ToString();
            con = new SqlConnection(constr);
        }

        public int Alta(Abastecimiento abastecimiento)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("insert into Abastecimiento(IdSucursalEnv,IdSucursalRec,IdProducto,Fecha,IdUser) values (@IdSucursalEnv,@IdSucursalRec,@IdProducto,@Fecha,@IdUser)", con);

            //Id,IdSucursalEnv,IdSucursalRec,IdProducto,Fecha,IdUser  @Id,@IdSucursalEnv,@IdSucursalRec,@IdProducto,@Fecha,@IdUser            
            comando.Parameters.Add("@IdSucursalEnv", SqlDbType.Int);
            comando.Parameters.Add("@IdSucursalRec", SqlDbType.Int);
            comando.Parameters.Add("@IdProducto", SqlDbType.Int);
            comando.Parameters.Add("@Fecha", SqlDbType.Date);
            comando.Parameters.Add("@IdUser", SqlDbType.Int);
            
            comando.Parameters["@IdSucursalEnv"].Value = abastecimiento.IdSucursalEnv;
            comando.Parameters["@IdSucursalRec"].Value = abastecimiento.IdSucursalRec;
            comando.Parameters["@IdProducto"].Value = abastecimiento.IdProducto;
            comando.Parameters["@Fecha"].Value = abastecimiento.Fecha;
            comando.Parameters["@IdUser"].Value = abastecimiento.IdUser;

            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }


        public List<Abastecimiento> RecuperarTodos()
        {
            Conectar();
            List<Abastecimiento> abastecimientos = new List<Abastecimiento>();

            SqlCommand com = new SqlCommand("select Id,IdSucursalEnv,IdSucursalRec,IdProducto,Fecha,IdUser from Abastecimiento", con);
            con.Open();
            SqlDataReader registros = com.ExecuteReader();
            while (registros.Read())
            {
                Abastecimiento abastecimiento = new Abastecimiento
                {
                    //Id,IdSucursalEnv,IdSucursalRec,IdProducto,Fecha,IdUser  @Id,@IdSucursalEnv,@IdSucursalRec,@IdProducto,@Fecha,@IdUser
                    Id = int.Parse(registros["Id"].ToString()),
                    IdSucursalEnv = int.Parse(registros["IdSucursalEnv"].ToString()),
                    IdSucursalRec = int.Parse(registros["IdSucursalRec"].ToString()),
                    IdProducto = int.Parse(registros["IdProducto"].ToString()),
                    Fecha = DateTime.Parse(registros["Fecha"].ToString()),
                    IdUser = int.Parse(registros["IdUser"].ToString()),
                   

                };
                abastecimientos.Add(abastecimiento);
            }
            con.Close();
            return abastecimientos;
        }


        public Abastecimiento Recuperar(int Id)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("select Id,IdSucursalEnv,IdSucursalRec,IdProducto,Fecha,IdUser from Abastecimiento where Id=@Id", con);
            comando.Parameters.Add("@Id", SqlDbType.Int);
            comando.Parameters["@Id"].Value = Id;
            con.Open();
            SqlDataReader registros = comando.ExecuteReader();
            Abastecimiento abastecimiento = new Abastecimiento();
            if (registros.Read())
            {
                //Id,IdSucursalEnv,IdSucursalRec,IdProducto,Fecha,IdUser  @Id,@IdSucursalEnv,@IdSucursalRec,@IdProducto,@Fecha,@IdUser
                abastecimiento.Id = int.Parse(registros["Id"].ToString());
                abastecimiento.IdSucursalEnv = int.Parse(registros["IdSucursalEnv"].ToString());
                abastecimiento.IdSucursalRec= int.Parse(registros["IdSucursalRec"].ToString());
                abastecimiento.IdProducto = int.Parse(registros["IdProducto"].ToString());
                abastecimiento.Fecha= DateTime.Parse(registros["Fecha"].ToString());
                abastecimiento.IdUser = int.Parse(registros["IdUser"].ToString());

            }
            con.Close();
            return abastecimiento;
        }

        public int Modificar(Abastecimiento abastecimiento)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("update Abastecimiento set Id=@Id,IdSucursalEnv=@IdSucursalEnv,IdSucursalRec=@IdSucursalRec,IdProducto=@IdProducto,Fecha=@Fecha,IdUser=@IdUser where Id=@id", con);
            //Id,IdSucursalEnv,IdSucursalRec,IdProducto,Fecha,IdUser  @Id,@IdSucursalEnv,@IdSucursalRec,@IdProducto,@Fecha,@IdUser
            comando.Parameters.Add("@Id", SqlDbType.Int);
            comando.Parameters.Add("@IdSucursalEnv", SqlDbType.Int);
            comando.Parameters.Add("@IdSucursalRec", SqlDbType.Int);
            comando.Parameters.Add("@IdProducto", SqlDbType.Int);
            comando.Parameters.Add("@Fecha", SqlDbType.Date);
            comando.Parameters.Add("@IdUser", SqlDbType.Int);


            comando.Parameters["@Id"].Value = abastecimiento.Id;
            comando.Parameters["@IdSucursalEnv"].Value = abastecimiento.IdSucursalEnv;
            comando.Parameters["@IdSucursalRec"].Value = abastecimiento.IdSucursalRec;
            comando.Parameters["@IdProducto"].Value = abastecimiento.IdProducto;
            comando.Parameters["@Fecha"].Value = abastecimiento.Fecha;
            comando.Parameters["@IdUser"].Value = abastecimiento.IdUser;

            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public int Borrar(int Id)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("delete from Abastecimiento where Id=@Id", con);
            comando.Parameters.Add("@Id", SqlDbType.Int);
            comando.Parameters["@Id"].Value = Id;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
}