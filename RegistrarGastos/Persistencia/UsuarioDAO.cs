using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RegistrarGastos.Persistencia
{
    public class UsuarioDAO
    {
        //private String cadenaConexion = "Data Source = (local); Initial Catalog = BDInmueble; Integrated Security = SSPI;";
        private static string cadenaConexion = "Data Source=.;Initial Catalog=proyecto_dst;user id=sa; password=Nnnvvv2019";
        public Usuario Crear(Usuario UsuarioACrear)
        {
            Usuario UsuarioCreado = null;
            string sql = "INSERT INTO t_usuario VALUES(@dni, @nombre, @apellido, @sexo,@password, @celular,@esInquilino)";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@dni", UsuarioACrear.Dni));
                    comando.Parameters.Add(new SqlParameter("@nombre", UsuarioACrear.Nombre));
                    comando.Parameters.Add(new SqlParameter("@apellido", UsuarioACrear.Apellido));
                    comando.Parameters.Add(new SqlParameter("@sexo", UsuarioACrear.Sexo));
                    comando.Parameters.Add(new SqlParameter("@password", UsuarioACrear.password));
                    comando.Parameters.Add(new SqlParameter("@celular", UsuarioACrear.celular));
                    comando.Parameters.Add(new SqlParameter("@esInquilino", UsuarioACrear.esInquilino));
                    comando.ExecuteNonQuery();
                }
            }
            UsuarioCreado = Obtener(UsuarioACrear.Dni);
            return UsuarioCreado;

        }
        public Usuario Obtener(int dni)
        {
            Usuario UsuarioEncontrado = null;
            string sql = "SELECT *FROM t_usuario WHERE dni = @dni";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@dni", dni));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            UsuarioEncontrado = new Usuario()
                            {
                                Dni = (int)resultado["dni"],
                                Nombre = (String)resultado["nombre"],
                                Apellido = (String)resultado["apellido"],
                                Sexo = (String)resultado["sexo"],
                                password = (String)resultado["password"],
                                celular = (String)resultado["celular"],
                                esInquilino = (int)resultado["esInquilino"],
                            };
                        }
                    }
                }
            }
            return UsuarioEncontrado;
        }
        public Usuario Modificar(Usuario UsuarioAModificar)
        {

            Usuario UsuarioModificado = null;
            string sql = "UPDATE t_usuario SET nombre=@nombre, apellido = @apellido, sexo = @sexo, password=@password, celular=@celular, esInquilino=@esInquilino WHERE dni= @dni";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@dni", UsuarioAModificar.Dni));
                    comando.Parameters.Add(new SqlParameter("@nombre", UsuarioAModificar.Nombre));
                    comando.Parameters.Add(new SqlParameter("@apellido", UsuarioAModificar.Apellido));
                    comando.Parameters.Add(new SqlParameter("@sexo", UsuarioAModificar.Sexo));
                    comando.Parameters.Add(new SqlParameter("@password", UsuarioAModificar.password));
                    comando.Parameters.Add(new SqlParameter("@celular", UsuarioAModificar.celular));
                    comando.Parameters.Add(new SqlParameter("@esInquilino", UsuarioAModificar.esInquilino));
                    comando.ExecuteNonQuery();
                }

            }
            UsuarioModificado = Obtener(UsuarioAModificar.Dni);
            return UsuarioModificado;
        }
        public void Eliminar(int dni)
        {
            string sql = "DELETE FROM t_usuario WHERE dni=@dni";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@dni", dni));
                    comando.ExecuteNonQuery();
                }
            }
        }
        public List<Usuario> Listar()
        {

            List<Usuario> UsuariosEncontrados = new List<Usuario>();
            Usuario UsuarioEncontrado = null;
            string sql = "SELECT * from t_usuario";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            UsuarioEncontrado = new Usuario()
                            {
                                Dni = (int)resultado["dni"],
                                Nombre = (string)resultado["nombre"],
                                Apellido = (string)resultado["apellido"],
                                Sexo = (string)resultado["sexo"],
                                celular = (string)resultado["celular"],
                                esInquilino= (int)resultado["esInquilino"]
                                //password  = (string)resultado["password"]

                            };
                            UsuariosEncontrados.Add(UsuarioEncontrado);
                        }
                    }
                }
            }
            return UsuariosEncontrados;
        }

        public List<Usuario> ListarbyTipo(Usuario obj)
        {

            List<Usuario> UsuariosEncontrados = new List<Usuario>();
            Usuario UsuarioEncontrado = null;
            string sql = "SELECT * from t_usuario where esInquilino=@esInquilino";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();

                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@esInquilino", obj.esInquilino));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            UsuarioEncontrado = new Usuario()
                            {
                                Dni = (int)resultado["dni"],
                                Nombre = (string)resultado["nombre"],
                                Apellido = (string)resultado["apellido"],
                                Sexo = (string)resultado["sexo"],
                                celular = (string)resultado["celular"],
                                esInquilino = (int)resultado["esInquilino"]
                                //password  = (string)resultado["password"]

                            };
                            UsuariosEncontrados.Add(UsuarioEncontrado);
                        }
                    }
                }
            }
            return UsuariosEncontrados;
        }


        public bool Login(Usuario obj)
        {
            Usuario UsuarioEncontrado = null;
            string sql = "SELECT *FROM t_usuario WHERE dni = @dni and password=@password";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                { 
                    comando.Parameters.Add(new SqlParameter("@dni", obj.Dni));
                    comando.Parameters.Add(new SqlParameter("@password", obj.password));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (!resultado.HasRows)
                            return false;
                        if (resultado.Read())
                        {
                            UsuarioEncontrado = new Usuario()
                            {
                                Dni = (int)resultado["dni"],
                                Nombre = (String)resultado["nombre"],
                                Apellido = (String)resultado["apellido"],
                                Sexo = (String)resultado["sexo"],
                                password = (String)resultado["password"],
                            };
                        }
                    }
                }
            }
            if (UsuarioEncontrado != null)
                return true;
            else return false;

        }

    }
}