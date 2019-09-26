using RegistrarGastos.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RegistrarGastos.Persistencia
{
    public class InmueblesDAO
    {
        private static string CadenaConexion = "Data Source=.;Initial Catalog=proyecto_dst;user id=sa; password=Nnnvvv2019";
        public Inmuebles Crear(Inmuebles inmuebleACrear)
        {
            Inmuebles inmuebleCreada = null;
            string sql = "INSERT INTO t_inmueble VALUES(@direccion,@codigo, @gAlquiler, @gMantenimiento, @gAdicionales,@idInquilino)";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@direccion", inmuebleACrear.direccion));
                    comando.Parameters.Add(new SqlParameter("@codigo", inmuebleACrear.codigo));
                    comando.Parameters.Add(new SqlParameter("@gAlquiler", inmuebleACrear.gAlquiler));                    
                    comando.Parameters.Add(new SqlParameter("@gMantenimiento", inmuebleACrear.gMantenimiento));
                    comando.Parameters.Add(new SqlParameter("@gAdicionales", inmuebleACrear.gAdicionales));
                    comando.Parameters.Add(new SqlParameter("@idInquilino", inmuebleACrear.idInquilino));
                    comando.ExecuteNonQuery();
                }
            }
            inmuebleCreada = Obtener(inmuebleACrear.codigo);
            return inmuebleCreada;
        }

        public Inmuebles Obtener(string id)
        {
            Inmuebles inmuebleEncontrada = null;
            string sql = "SELECT * FROM t_inmueble WHERE codigo = @codigo";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@codigo", id));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            inmuebleEncontrada = new Inmuebles()
                            {
                                direccion = (string)resultado["direccion"],
                                codigo = (string)resultado["codigo"],
                                gAlquiler = (decimal)resultado["gAlquiler"],
                                gMantenimiento = (decimal)resultado["gMantenimiento"],
                                gAdicionales = (decimal)resultado["gAdicionales"],
                                idInquilino = (int)resultado["idInquilino"]

                            };
                        }
                    }
                }
            }
            return inmuebleEncontrada;
        }

        public Inmuebles ObtenerbyInqulino(int id)
        {
            Inmuebles inmuebleEncontrada = null;
            string sql = "SELECT * FROM t_inmueble WHERE idInquilino = @idInquilino";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@idInquilino", id));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            inmuebleEncontrada = new Inmuebles()
                            {
                                direccion = (string)resultado["direccion"],
                                codigo = (string)resultado["codigo"],
                                gAlquiler = (decimal)resultado["gAlquiler"],
                                gMantenimiento = (decimal)resultado["gMantenimiento"],
                                gAdicionales = (decimal)resultado["gAdicionales"],
                                idInquilino = (int)resultado["idInquilino"]

                            };
                        }
                    }
                }
            }
            return inmuebleEncontrada;
        }
    }
}