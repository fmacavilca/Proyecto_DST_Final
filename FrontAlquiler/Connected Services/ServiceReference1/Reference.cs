﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FrontAlquiler.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Inmuebles", Namespace="http://schemas.datacontract.org/2004/07/RegistrarGastos.Dominio")]
    [System.SerializableAttribute()]
    public partial class Inmuebles : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string codigoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string direccionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal gAdicionalesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal gAlquilerField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal gMantenimientoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int idInmuebleField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int idInquilinoField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string codigo {
            get {
                return this.codigoField;
            }
            set {
                if ((object.ReferenceEquals(this.codigoField, value) != true)) {
                    this.codigoField = value;
                    this.RaisePropertyChanged("codigo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string direccion {
            get {
                return this.direccionField;
            }
            set {
                if ((object.ReferenceEquals(this.direccionField, value) != true)) {
                    this.direccionField = value;
                    this.RaisePropertyChanged("direccion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal gAdicionales {
            get {
                return this.gAdicionalesField;
            }
            set {
                if ((this.gAdicionalesField.Equals(value) != true)) {
                    this.gAdicionalesField = value;
                    this.RaisePropertyChanged("gAdicionales");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal gAlquiler {
            get {
                return this.gAlquilerField;
            }
            set {
                if ((this.gAlquilerField.Equals(value) != true)) {
                    this.gAlquilerField = value;
                    this.RaisePropertyChanged("gAlquiler");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal gMantenimiento {
            get {
                return this.gMantenimientoField;
            }
            set {
                if ((this.gMantenimientoField.Equals(value) != true)) {
                    this.gMantenimientoField = value;
                    this.RaisePropertyChanged("gMantenimiento");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int idInmueble {
            get {
                return this.idInmuebleField;
            }
            set {
                if ((this.idInmuebleField.Equals(value) != true)) {
                    this.idInmuebleField = value;
                    this.RaisePropertyChanged("idInmueble");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int idInquilino {
            get {
                return this.idInquilinoField;
            }
            set {
                if ((this.idInquilinoField.Equals(value) != true)) {
                    this.idInquilinoField = value;
                    this.RaisePropertyChanged("idInquilino");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Excepciones", Namespace="http://schemas.datacontract.org/2004/07/RegistrarGastos.Errores")]
    [System.SerializableAttribute()]
    public partial class Excepciones : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CodigoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescripcionField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Codigo {
            get {
                return this.CodigoField;
            }
            set {
                if ((object.ReferenceEquals(this.CodigoField, value) != true)) {
                    this.CodigoField = value;
                    this.RaisePropertyChanged("Codigo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Descripcion {
            get {
                return this.DescripcionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescripcionField, value) != true)) {
                    this.DescripcionField = value;
                    this.RaisePropertyChanged("Descripcion");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IRegistrarGastos")]
    public interface IRegistrarGastos {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRegistrarGastos/CrearInmueble", ReplyAction="http://tempuri.org/IRegistrarGastos/CrearInmuebleResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(FrontAlquiler.ServiceReference1.Excepciones), Action="http://tempuri.org/IRegistrarGastos/CrearInmuebleExcepcionesFault", Name="Excepciones", Namespace="http://schemas.datacontract.org/2004/07/RegistrarGastos.Errores")]
        FrontAlquiler.ServiceReference1.Inmuebles CrearInmueble(FrontAlquiler.ServiceReference1.Inmuebles InmuebleACrear);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRegistrarGastos/CrearInmueble", ReplyAction="http://tempuri.org/IRegistrarGastos/CrearInmuebleResponse")]
        System.Threading.Tasks.Task<FrontAlquiler.ServiceReference1.Inmuebles> CrearInmuebleAsync(FrontAlquiler.ServiceReference1.Inmuebles InmuebleACrear);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRegistrarGastos/Obtener", ReplyAction="http://tempuri.org/IRegistrarGastos/ObtenerResponse")]
        FrontAlquiler.ServiceReference1.Inmuebles Obtener(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRegistrarGastos/Obtener", ReplyAction="http://tempuri.org/IRegistrarGastos/ObtenerResponse")]
        System.Threading.Tasks.Task<FrontAlquiler.ServiceReference1.Inmuebles> ObtenerAsync(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRegistrarGastos/ObtenerbyInquilino", ReplyAction="http://tempuri.org/IRegistrarGastos/ObtenerbyInquilinoResponse")]
        FrontAlquiler.ServiceReference1.Inmuebles ObtenerbyInquilino(FrontAlquiler.ServiceReference1.Inmuebles obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRegistrarGastos/ObtenerbyInquilino", ReplyAction="http://tempuri.org/IRegistrarGastos/ObtenerbyInquilinoResponse")]
        System.Threading.Tasks.Task<FrontAlquiler.ServiceReference1.Inmuebles> ObtenerbyInquilinoAsync(FrontAlquiler.ServiceReference1.Inmuebles obj);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IRegistrarGastosChannel : FrontAlquiler.ServiceReference1.IRegistrarGastos, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class RegistrarGastosClient : System.ServiceModel.ClientBase<FrontAlquiler.ServiceReference1.IRegistrarGastos>, FrontAlquiler.ServiceReference1.IRegistrarGastos {
        
        public RegistrarGastosClient() {
        }
        
        public RegistrarGastosClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public RegistrarGastosClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RegistrarGastosClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RegistrarGastosClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public FrontAlquiler.ServiceReference1.Inmuebles CrearInmueble(FrontAlquiler.ServiceReference1.Inmuebles InmuebleACrear) {
            return base.Channel.CrearInmueble(InmuebleACrear);
        }
        
        public System.Threading.Tasks.Task<FrontAlquiler.ServiceReference1.Inmuebles> CrearInmuebleAsync(FrontAlquiler.ServiceReference1.Inmuebles InmuebleACrear) {
            return base.Channel.CrearInmuebleAsync(InmuebleACrear);
        }
        
        public FrontAlquiler.ServiceReference1.Inmuebles Obtener(string id) {
            return base.Channel.Obtener(id);
        }
        
        public System.Threading.Tasks.Task<FrontAlquiler.ServiceReference1.Inmuebles> ObtenerAsync(string id) {
            return base.Channel.ObtenerAsync(id);
        }
        
        public FrontAlquiler.ServiceReference1.Inmuebles ObtenerbyInquilino(FrontAlquiler.ServiceReference1.Inmuebles obj) {
            return base.Channel.ObtenerbyInquilino(obj);
        }
        
        public System.Threading.Tasks.Task<FrontAlquiler.ServiceReference1.Inmuebles> ObtenerbyInquilinoAsync(FrontAlquiler.ServiceReference1.Inmuebles obj) {
            return base.Channel.ObtenerbyInquilinoAsync(obj);
        }
    }
}