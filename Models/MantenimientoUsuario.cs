using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.UI.WebControls.WebParts;

namespace Proyecto_Tienda.Models
{
    public class MantenimientoUsuario
    {

        private SqlConnection con;

        private void Conectar()
        {
            string constr = ConfigurationManager.ConnectionStrings["administracion"].ToString();
            con = new SqlConnection(constr);
        }

        public int Alta(Usuario user)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("insert into Usuario(Usuario,Contraseña,IdArea,IdTIenda) values (@Usuario,@Contraseña,@IdArea,@IdTienda)", con);
            ///Id,Usuario,Contraseña,IdArea,IdTienda  @Id,@Usuario,@Contraseña,@IdArea,@IdTienda
            comando.Parameters.Add("@Usuario", SqlDbType.VarChar);
            comando.Parameters.Add("@Contraseña", SqlDbType.VarChar);
            comando.Parameters.Add("@IdArea", SqlDbType.Int);
            comando.Parameters.Add("@IdTienda", SqlDbType.Int);

            comando.Parameters["@Usuario"].Value = user.User;
            comando.Parameters["@Contraseña"].Value = user.Contraseña;
            comando.Parameters["@IdArea"].Value = user.IdArea;
            comando.Parameters["@IdTienda"].Value = user.IdTienda;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }


        public List<Usuario> RecuperarTodos()
        {
            Conectar();
            List<Usuario> usuarios = new List<Usuario>();

            SqlCommand com = new SqlCommand("select Id,Usuario,Contraseña,IdArea,IdTienda from Usuario", con);
            con.Open();
            SqlDataReader registros = com.ExecuteReader();
            while (registros.Read())
            {
                Usuario user = new Usuario
                {
                    ///Id,Usuario,Contraseña,IdArea,IdTienda  @Id,@Usuario,@Contraseña,@IdArea,@IdTienda
                    Id = int.Parse(registros["Id"].ToString()),
                    User = registros["Usuario"].ToString(),
                    Contraseña = registros["Contraseña"].ToString(),
                    IdArea = int.Parse(registros["IdArea"].ToString()),
                    IdTienda = int.Parse(registros["IdTienda"].ToString()),
                    

                };
                usuarios.Add(user);
            }
            con.Close();
            return usuarios;
        }


        public Usuario Recuperar(int Id)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("select Id,Usuario,Contraseña,IdArea,IdTienda from Usuario where Id=@Id", con);
            comando.Parameters.Add("@Id", SqlDbType.Int);
            comando.Parameters["@Id"].Value = Id;
            con.Open();
            SqlDataReader registros = comando.ExecuteReader();
            Usuario usuario = new Usuario();
            if (registros.Read())
            {
                ///Id,Usuario,Contraseña,IdArea,IdTienda  @Id,@Usuario,@Contraseña,@IdArea,@IdTienda
               usuario.Id = int.Parse(registros["Id"].ToString());
                usuario.User = registros["Usuario"].ToString();
                usuario.Contraseña = registros["Contraseña"].ToString();
                usuario.IdArea = int.Parse(registros["IdArea"].ToString());
                usuario.IdTienda = int.Parse(registros["IdTienda"].ToString());
            }
            con.Close();
            return usuario;
        }

        public int Modificar(Usuario user)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("update Usuario set Usuario=@Usuario,Contraseña=@Contraseña,IdArea=@IdArea,IdTienda=@IdTienda where Id=@id", con);
            ///Id,Usuario,Contraseña,IdArea,IdTienda  @Id,@Usuario,@Contraseña,@IdArea,@IdTienda
                        
            comando.Parameters.Add("@Id", SqlDbType.Int);
            comando.Parameters["@Id"].Value = user.Id;
            comando.Parameters.Add("@Usuario", SqlDbType.VarChar);
            comando.Parameters["@Usuario"].Value = user.User;
            comando.Parameters.Add("@Contraseña", SqlDbType.VarChar);
            comando.Parameters["@Contraseña"].Value = user.Contraseña;
            comando.Parameters.Add("@IdArea", SqlDbType.Int);
            comando.Parameters["@IdArea"].Value = user.IdArea;
            comando.Parameters.Add("@IdTienda", SqlDbType.Int);
            comando.Parameters["@IdTienda"].Value = user.IdTienda;
                        
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public int Borrar(int Id)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("delete from Usuario where Id=@Id", con);
            comando.Parameters.Add("@Id", SqlDbType.Int);
            comando.Parameters["@Id"].Value = Id;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }



    }
}