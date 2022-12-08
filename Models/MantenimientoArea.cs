using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Proyecto_Tienda.Models
{
    public class MantenimientoArea
    {

        private SqlConnection con;

        private void Conectar()
        {
            string constr = ConfigurationManager.ConnectionStrings["administracion"].ToString();
            con = new SqlConnection(constr);
        }

        public int Alta(Area area)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("insert into Area(AreaTrabajo) values (@AreaTrabajo)", con);
            ///Id,AreaTrabajo,  @Id,@AreaTrabajo
            comando.Parameters.Add("@AreaTrabajo", SqlDbType.VarChar);
           


            
            comando.Parameters["@AreaTrabajo"].Value = area.AreaTrabajo;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }


        public List<Area> RecuperarTodos()
        {
            Conectar();
            List<Area> area = new List<Area>();

            SqlCommand com = new SqlCommand("select Id,AreaTrabajo from Area", con);
            con.Open();
            SqlDataReader registros = com.ExecuteReader();
            while (registros.Read())
            {
                Area areas = new Area
                {
                    ///Id,AreaTrabajo,  @Id,@AreaTrabajo
                    Id = int.Parse(registros["Id"].ToString()),
                    AreaTrabajo = registros["AreaTrabajo"].ToString(),
                    
                };
                area.Add(areas);
            }
            con.Close();
            return area;
        }


        public Area Recuperar(int Id)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("select Id,AreaTrabajo from Area where Id=@Id", con);
            comando.Parameters.Add("@Id", SqlDbType.Int);
            comando.Parameters["@Id"].Value = Id;
            con.Open();
            SqlDataReader registros = comando.ExecuteReader();
            Area area = new Area();
            if (registros.Read())
            {
                
                area.Id = int.Parse(registros["Id"].ToString());
                area.AreaTrabajo = registros["AreaTrabajo"].ToString();
                
            }
            con.Close();
            return area;
        }

        public int Modificar(Area area)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("update Area set AreaTrabajo=@AreaTrabajo where Id=@id", con);

            comando.Parameters.Add("@Id",SqlDbType.Int);
            comando.Parameters["@Id"].Value = area.Id;

            comando.Parameters.Add("@AreaTrabajo",SqlDbType.VarChar);
            comando.Parameters["@AreaTrabajo"].Value = area.AreaTrabajo;
          

            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public int Borrar(int Id)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("delete from Area where Id=@Id", con);
            comando.Parameters.Add("@Id", SqlDbType.Int);
            comando.Parameters["@Id"].Value = Id;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
}