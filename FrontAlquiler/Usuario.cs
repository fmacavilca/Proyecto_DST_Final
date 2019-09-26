using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FrontAlquiler
{
    [DataContract]
    public class Usuario
    {
        [DataMember]
        public int Dni { get; set; }
        [DataMember]
        public String Nombre { get; set; }
        [DataMember]
        public String Apellido { get; set; }
        [DataMember(IsRequired = false)]
        public String Sexo { get; set; }
        [DataMember]
        public String password { get; set; }
        [DataMember]
        public String celular { get; set; }
        [DataMember]
        public int esInquilino { get; set; }
    }
}
