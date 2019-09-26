using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RegistrarGastos.Dominio
{
    [DataContract]
    public class Inmuebles
    {
        [DataMember]
        public int idInmueble { get; set; }

        [DataMember]
        public string direccion { get; set; }

        [DataMember]
        public string codigo { get; set; }

        [DataMember]
        public decimal gAlquiler { get; set; }

        [DataMember]
        public decimal gMantenimiento { get; set; }

        [DataMember]
        public decimal gAdicionales { get; set; }

        [DataMember]
        public int idInquilino { get; set; }
    }
}