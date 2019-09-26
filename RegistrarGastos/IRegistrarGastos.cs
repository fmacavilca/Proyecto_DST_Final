using RegistrarGastos.Dominio;
using RegistrarGastos.Errores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RegistrarGastos
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IRegistrarGastos" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IRegistrarGastos
    {
        [FaultContract(typeof(Excepciones))]
        [OperationContract]
        Inmuebles CrearInmueble(Inmuebles InmuebleACrear);
        [OperationContract]
        Inmuebles Obtener(string id);

        [OperationContract]
        Inmuebles ObtenerbyInquilino(Inmuebles obj);
    }
}
