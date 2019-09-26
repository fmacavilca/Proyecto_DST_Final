using RegistrarGastos.Errores;
using RegistrarGastos.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RegistrarGastos
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "IUsuario" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione IUsuario.svc o IUsuario.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class IUsuario : IIUsuario
    {
        private UsuarioDAO UsuarioDAO = new UsuarioDAO();
        public Usuario CrearUsuario(Usuario UsuarioACrear)
        {
            Usuario UsuarioExistente = UsuarioDAO.Obtener(UsuarioACrear.Dni);
            if (UsuarioExistente != null)
            {
                throw new WebFaultException<Excepciones>(
                    new Excepciones()
                    {
                        Codigo = "102",
                        Descripcion = "DNI duplicado"
                    }, HttpStatusCode.Conflict);
            }
            return UsuarioDAO.Crear(UsuarioACrear);
        }
        public void EliminarUsuario(string dni)
        {
            UsuarioDAO.Eliminar(int.Parse(dni));
        }
        public List<Usuario> ListarUsuarios()
        {
            return UsuarioDAO.Listar();
        }
        public Usuario ModificarUsuario(Usuario UsuarioAModificar)
        {
            return UsuarioDAO.Modificar(UsuarioAModificar);
        }
        public Usuario ObtenerUsuario(string dni)
        {
            return UsuarioDAO.Obtener(int.Parse(dni));
        }
        public List<Usuario> ListarbyTipo(string esInquilino)
        {
            Usuario obj = new Usuario();
            obj.esInquilino = int.Parse(esInquilino);

            return UsuarioDAO.ListarbyTipo(obj);
        }
        public bool Login(string dni, string password)
        {
            Usuario obj = new Usuario();
            obj.Dni = int.Parse(dni);
            obj.password = password;
            return UsuarioDAO.Login(obj);
        }
    }
}
