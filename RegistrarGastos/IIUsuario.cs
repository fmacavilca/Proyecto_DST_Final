using RegistrarGastos.Errores;
using RegistrarGastos.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RegistrarGastos
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IIUsuario" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IIUsuario
    {
        
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "CrearUsuario", ResponseFormat = WebMessageFormat.Json)]
        Usuario CrearUsuario(Usuario UsuarioACrear);
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Usuario/{dni}", ResponseFormat = WebMessageFormat.Json)]
        Usuario ObtenerUsuario(string dni);
        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "ModificarUsuario", ResponseFormat = WebMessageFormat.Json)]
        Usuario ModificarUsuario(Usuario UsuarioAModificar);
        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "Usuarios/{dni}", ResponseFormat = WebMessageFormat.Json)]
        void EliminarUsuario(string dni);
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Usuarios", ResponseFormat = WebMessageFormat.Json)]
        List<Usuario> ListarUsuarios();
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "UsuariosbyTipo/{isInquilino}", ResponseFormat = WebMessageFormat.Json)]
        List<Usuario> ListarbyTipo(string isInquilino);
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Login/{dni}/{password}", ResponseFormat = WebMessageFormat.Json)]
        bool Login(string dni, string password);

    }
}
