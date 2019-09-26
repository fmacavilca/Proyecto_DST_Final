using RegistrarGastos.Dominio;
using RegistrarGastos.Errores;
using RegistrarGastos.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RegistrarGastos
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "RegistrarGastos" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione RegistrarGastos.svc o RegistrarGastos.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class RegistrarGastos : IRegistrarGastos
    {

        private InmueblesDAO inmueblesDAO = new InmueblesDAO();
        public Inmuebles CrearInmueble(Inmuebles InmuebleACrear)
        {
            if (inmueblesDAO.Obtener(InmuebleACrear.codigo) != null)
            {
                throw new FaultException<Excepciones>(
                    new Excepciones()
                    {
                        Codigo = "505",
                        Descripcion = "El inmueble ya existe"
                    },
                    new FaultReason("Error al intentar crear"));
            }

            if (InmuebleACrear.gAdicionales < 0)
            {
                throw new FaultException<Excepciones>(
                    new Excepciones()
                    {
                        Codigo = "506",
                        Descripcion = "No puede ser negativo  el campo: Gastos Adicionales"
                    },
                    new FaultReason("Error al intentar crear"));
            }
            return inmueblesDAO.Crear(InmuebleACrear);
        }


        public  Inmuebles Obtener(string id)
        {
            return inmueblesDAO.Obtener(id);
        }

        public Inmuebles ObtenerbyInquilino(Inmuebles obj)
        {
            return inmueblesDAO.ObtenerbyInqulino(obj.idInquilino);
        }

    }
}
