﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3053
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 2.0.50727.3053.
// 
#pragma warning disable 1591

namespace etWeb.et {
    using System.Diagnostics;
    using System.Web.Services;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="FachadaSoap", Namespace="http://tempuri.org/")]
    public partial class Fachada : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback validarUsuarioOperationCompleted;
        
        private System.Threading.SendOrPostCallback obtenerPermisosPorUsuarioOperationCompleted;
        
        private System.Threading.SendOrPostCallback listaEncuestasOperationCompleted;
        
        private System.Threading.SendOrPostCallback listaEncuestas2OperationCompleted;
        
        private System.Threading.SendOrPostCallback encuestaPorIdOperationCompleted;
        
        private System.Threading.SendOrPostCallback insertarEncuestaOperationCompleted;
        
        private System.Threading.SendOrPostCallback actualizarEncuestaOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public Fachada() {
            this.Url = global::etWeb.Properties.Settings.Default.etWeb_localhost_Fachada;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event validarUsuarioCompletedEventHandler validarUsuarioCompleted;
        
        /// <remarks/>
        public event obtenerPermisosPorUsuarioCompletedEventHandler obtenerPermisosPorUsuarioCompleted;
        
        /// <remarks/>
        public event listaEncuestasCompletedEventHandler listaEncuestasCompleted;
        
        /// <remarks/>
        public event listaEncuestas2CompletedEventHandler listaEncuestas2Completed;
        
        /// <remarks/>
        public event encuestaPorIdCompletedEventHandler encuestaPorIdCompleted;
        
        /// <remarks/>
        public event insertarEncuestaCompletedEventHandler insertarEncuestaCompleted;
        
        /// <remarks/>
        public event actualizarEncuestaCompletedEventHandler actualizarEncuestaCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/validarUsuario", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool validarUsuario(string usuario, string password) {
            object[] results = this.Invoke("validarUsuario", new object[] {
                        usuario,
                        password});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void validarUsuarioAsync(string usuario, string password) {
            this.validarUsuarioAsync(usuario, password, null);
        }
        
        /// <remarks/>
        public void validarUsuarioAsync(string usuario, string password, object userState) {
            if ((this.validarUsuarioOperationCompleted == null)) {
                this.validarUsuarioOperationCompleted = new System.Threading.SendOrPostCallback(this.OnvalidarUsuarioOperationCompleted);
            }
            this.InvokeAsync("validarUsuario", new object[] {
                        usuario,
                        password}, this.validarUsuarioOperationCompleted, userState);
        }
        
        private void OnvalidarUsuarioOperationCompleted(object arg) {
            if ((this.validarUsuarioCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.validarUsuarioCompleted(this, new validarUsuarioCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/obtenerPermisosPorUsuario", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string obtenerPermisosPorUsuario(string usuario) {
            object[] results = this.Invoke("obtenerPermisosPorUsuario", new object[] {
                        usuario});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void obtenerPermisosPorUsuarioAsync(string usuario) {
            this.obtenerPermisosPorUsuarioAsync(usuario, null);
        }
        
        /// <remarks/>
        public void obtenerPermisosPorUsuarioAsync(string usuario, object userState) {
            if ((this.obtenerPermisosPorUsuarioOperationCompleted == null)) {
                this.obtenerPermisosPorUsuarioOperationCompleted = new System.Threading.SendOrPostCallback(this.OnobtenerPermisosPorUsuarioOperationCompleted);
            }
            this.InvokeAsync("obtenerPermisosPorUsuario", new object[] {
                        usuario}, this.obtenerPermisosPorUsuarioOperationCompleted, userState);
        }
        
        private void OnobtenerPermisosPorUsuarioOperationCompleted(object arg) {
            if ((this.obtenerPermisosPorUsuarioCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.obtenerPermisosPorUsuarioCompleted(this, new obtenerPermisosPorUsuarioCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/listaEncuestas", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string listaEncuestas() {
            object[] results = this.Invoke("listaEncuestas", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void listaEncuestasAsync() {
            this.listaEncuestasAsync(null);
        }
        
        /// <remarks/>
        public void listaEncuestasAsync(object userState) {
            if ((this.listaEncuestasOperationCompleted == null)) {
                this.listaEncuestasOperationCompleted = new System.Threading.SendOrPostCallback(this.OnlistaEncuestasOperationCompleted);
            }
            this.InvokeAsync("listaEncuestas", new object[0], this.listaEncuestasOperationCompleted, userState);
        }
        
        private void OnlistaEncuestasOperationCompleted(object arg) {
            if ((this.listaEncuestasCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.listaEncuestasCompleted(this, new listaEncuestasCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/listaEncuestas2", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public encuesta[] listaEncuestas2() {
            object[] results = this.Invoke("listaEncuestas2", new object[0]);
            return ((encuesta[])(results[0]));
        }
        
        /// <remarks/>
        public void listaEncuestas2Async() {
            this.listaEncuestas2Async(null);
        }
        
        /// <remarks/>
        public void listaEncuestas2Async(object userState) {
            if ((this.listaEncuestas2OperationCompleted == null)) {
                this.listaEncuestas2OperationCompleted = new System.Threading.SendOrPostCallback(this.OnlistaEncuestas2OperationCompleted);
            }
            this.InvokeAsync("listaEncuestas2", new object[0], this.listaEncuestas2OperationCompleted, userState);
        }
        
        private void OnlistaEncuestas2OperationCompleted(object arg) {
            if ((this.listaEncuestas2Completed != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.listaEncuestas2Completed(this, new listaEncuestas2CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/encuestaPorId", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string encuestaPorId(string id) {
            object[] results = this.Invoke("encuestaPorId", new object[] {
                        id});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void encuestaPorIdAsync(string id) {
            this.encuestaPorIdAsync(id, null);
        }
        
        /// <remarks/>
        public void encuestaPorIdAsync(string id, object userState) {
            if ((this.encuestaPorIdOperationCompleted == null)) {
                this.encuestaPorIdOperationCompleted = new System.Threading.SendOrPostCallback(this.OnencuestaPorIdOperationCompleted);
            }
            this.InvokeAsync("encuestaPorId", new object[] {
                        id}, this.encuestaPorIdOperationCompleted, userState);
        }
        
        private void OnencuestaPorIdOperationCompleted(object arg) {
            if ((this.encuestaPorIdCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.encuestaPorIdCompleted(this, new encuestaPorIdCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/insertarEncuesta", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool insertarEncuesta(string xmlEncuesta) {
            object[] results = this.Invoke("insertarEncuesta", new object[] {
                        xmlEncuesta});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void insertarEncuestaAsync(string xmlEncuesta) {
            this.insertarEncuestaAsync(xmlEncuesta, null);
        }
        
        /// <remarks/>
        public void insertarEncuestaAsync(string xmlEncuesta, object userState) {
            if ((this.insertarEncuestaOperationCompleted == null)) {
                this.insertarEncuestaOperationCompleted = new System.Threading.SendOrPostCallback(this.OninsertarEncuestaOperationCompleted);
            }
            this.InvokeAsync("insertarEncuesta", new object[] {
                        xmlEncuesta}, this.insertarEncuestaOperationCompleted, userState);
        }
        
        private void OninsertarEncuestaOperationCompleted(object arg) {
            if ((this.insertarEncuestaCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.insertarEncuestaCompleted(this, new insertarEncuestaCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/actualizarEncuesta", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool actualizarEncuesta(string id, string xmlEncuesta) {
            object[] results = this.Invoke("actualizarEncuesta", new object[] {
                        id,
                        xmlEncuesta});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void actualizarEncuestaAsync(string id, string xmlEncuesta) {
            this.actualizarEncuestaAsync(id, xmlEncuesta, null);
        }
        
        /// <remarks/>
        public void actualizarEncuestaAsync(string id, string xmlEncuesta, object userState) {
            if ((this.actualizarEncuestaOperationCompleted == null)) {
                this.actualizarEncuestaOperationCompleted = new System.Threading.SendOrPostCallback(this.OnactualizarEncuestaOperationCompleted);
            }
            this.InvokeAsync("actualizarEncuesta", new object[] {
                        id,
                        xmlEncuesta}, this.actualizarEncuestaOperationCompleted, userState);
        }
        
        private void OnactualizarEncuestaOperationCompleted(object arg) {
            if ((this.actualizarEncuestaCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.actualizarEncuestaCompleted(this, new actualizarEncuestaCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3053")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class encuesta {
        
        private string nombreField;
        
        private string contrasenaField;
        
        private System.DateTime f_ingresoField;
        
        private System.Nullable<System.DateTime> f_modificacionField;
        
        private System.Nullable<System.DateTime> f_vigenciaField;
        
        private System.Nullable<System.DateTime> f_cierreField;
        
        private string id_agenteField;
        
        private string id_clienteField;
        
        private pregunta[] preguntasField;
        
        private usuario usuarioField;
        
        private usuario usuario1Field;
        
        /// <remarks/>
        public string nombre {
            get {
                return this.nombreField;
            }
            set {
                this.nombreField = value;
            }
        }
        
        /// <remarks/>
        public string contrasena {
            get {
                return this.contrasenaField;
            }
            set {
                this.contrasenaField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime f_ingreso {
            get {
                return this.f_ingresoField;
            }
            set {
                this.f_ingresoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<System.DateTime> f_modificacion {
            get {
                return this.f_modificacionField;
            }
            set {
                this.f_modificacionField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<System.DateTime> f_vigencia {
            get {
                return this.f_vigenciaField;
            }
            set {
                this.f_vigenciaField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<System.DateTime> f_cierre {
            get {
                return this.f_cierreField;
            }
            set {
                this.f_cierreField = value;
            }
        }
        
        /// <remarks/>
        public string id_agente {
            get {
                return this.id_agenteField;
            }
            set {
                this.id_agenteField = value;
            }
        }
        
        /// <remarks/>
        public string id_cliente {
            get {
                return this.id_clienteField;
            }
            set {
                this.id_clienteField = value;
            }
        }
        
        /// <remarks/>
        public pregunta[] preguntas {
            get {
                return this.preguntasField;
            }
            set {
                this.preguntasField = value;
            }
        }
        
        /// <remarks/>
        public usuario usuario {
            get {
                return this.usuarioField;
            }
            set {
                this.usuarioField = value;
            }
        }
        
        /// <remarks/>
        public usuario usuario1 {
            get {
                return this.usuario1Field;
            }
            set {
                this.usuario1Field = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3053")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class pregunta {
        
        private int idField;
        
        private string planteoField;
        
        private string condicionField;
        
        private System.Nullable<System.DateTime> f_ultima_respuestaField;
        
        private string id_encuestaField;
        
        private respuesta[] respuestasField;
        
        private encuesta encuestaField;
        
        /// <remarks/>
        public int id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        public string planteo {
            get {
                return this.planteoField;
            }
            set {
                this.planteoField = value;
            }
        }
        
        /// <remarks/>
        public string condicion {
            get {
                return this.condicionField;
            }
            set {
                this.condicionField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<System.DateTime> f_ultima_respuesta {
            get {
                return this.f_ultima_respuestaField;
            }
            set {
                this.f_ultima_respuestaField = value;
            }
        }
        
        /// <remarks/>
        public string id_encuesta {
            get {
                return this.id_encuestaField;
            }
            set {
                this.id_encuestaField = value;
            }
        }
        
        /// <remarks/>
        public respuesta[] respuestas {
            get {
                return this.respuestasField;
            }
            set {
                this.respuestasField = value;
            }
        }
        
        /// <remarks/>
        public encuesta encuesta {
            get {
                return this.encuestaField;
            }
            set {
                this.encuestaField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3053")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class respuesta {
        
        private int idField;
        
        private int contadorField;
        
        private string textoField;
        
        private int id_preguntaField;
        
        private pregunta preguntaField;
        
        /// <remarks/>
        public int id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        public int contador {
            get {
                return this.contadorField;
            }
            set {
                this.contadorField = value;
            }
        }
        
        /// <remarks/>
        public string texto {
            get {
                return this.textoField;
            }
            set {
                this.textoField = value;
            }
        }
        
        /// <remarks/>
        public int id_pregunta {
            get {
                return this.id_preguntaField;
            }
            set {
                this.id_preguntaField = value;
            }
        }
        
        /// <remarks/>
        public pregunta pregunta {
            get {
                return this.preguntaField;
            }
            set {
                this.preguntaField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3053")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class permiso {
        
        private int idField;
        
        private string nombreField;
        
        private string permiso1Field;
        
        private permiso_usuario[] permiso_usuariosField;
        
        /// <remarks/>
        public int id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        public string nombre {
            get {
                return this.nombreField;
            }
            set {
                this.nombreField = value;
            }
        }
        
        /// <remarks/>
        public string permiso1 {
            get {
                return this.permiso1Field;
            }
            set {
                this.permiso1Field = value;
            }
        }
        
        /// <remarks/>
        public permiso_usuario[] permiso_usuarios {
            get {
                return this.permiso_usuariosField;
            }
            set {
                this.permiso_usuariosField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3053")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class permiso_usuario {
        
        private string id_usuarioField;
        
        private int id_permisoField;
        
        private permiso permisoField;
        
        private usuario usuarioField;
        
        /// <remarks/>
        public string id_usuario {
            get {
                return this.id_usuarioField;
            }
            set {
                this.id_usuarioField = value;
            }
        }
        
        /// <remarks/>
        public int id_permiso {
            get {
                return this.id_permisoField;
            }
            set {
                this.id_permisoField = value;
            }
        }
        
        /// <remarks/>
        public permiso permiso {
            get {
                return this.permisoField;
            }
            set {
                this.permisoField = value;
            }
        }
        
        /// <remarks/>
        public usuario usuario {
            get {
                return this.usuarioField;
            }
            set {
                this.usuarioField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3053")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class usuario {
        
        private string nombreField;
        
        private string emailField;
        
        private string usuario1Field;
        
        private string contrasenaField;
        
        private string celularField;
        
        private string telefonoField;
        
        private System.Nullable<System.DateTime> f_ingresoField;
        
        private encuesta[] encuestasField;
        
        private encuesta[] encuestas1Field;
        
        private permiso_usuario[] permiso_usuariosField;
        
        /// <remarks/>
        public string nombre {
            get {
                return this.nombreField;
            }
            set {
                this.nombreField = value;
            }
        }
        
        /// <remarks/>
        public string email {
            get {
                return this.emailField;
            }
            set {
                this.emailField = value;
            }
        }
        
        /// <remarks/>
        public string usuario1 {
            get {
                return this.usuario1Field;
            }
            set {
                this.usuario1Field = value;
            }
        }
        
        /// <remarks/>
        public string contrasena {
            get {
                return this.contrasenaField;
            }
            set {
                this.contrasenaField = value;
            }
        }
        
        /// <remarks/>
        public string celular {
            get {
                return this.celularField;
            }
            set {
                this.celularField = value;
            }
        }
        
        /// <remarks/>
        public string telefono {
            get {
                return this.telefonoField;
            }
            set {
                this.telefonoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<System.DateTime> f_ingreso {
            get {
                return this.f_ingresoField;
            }
            set {
                this.f_ingresoField = value;
            }
        }
        
        /// <remarks/>
        public encuesta[] encuestas {
            get {
                return this.encuestasField;
            }
            set {
                this.encuestasField = value;
            }
        }
        
        /// <remarks/>
        public encuesta[] encuestas1 {
            get {
                return this.encuestas1Field;
            }
            set {
                this.encuestas1Field = value;
            }
        }
        
        /// <remarks/>
        public permiso_usuario[] permiso_usuarios {
            get {
                return this.permiso_usuariosField;
            }
            set {
                this.permiso_usuariosField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    public delegate void validarUsuarioCompletedEventHandler(object sender, validarUsuarioCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class validarUsuarioCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal validarUsuarioCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    public delegate void obtenerPermisosPorUsuarioCompletedEventHandler(object sender, obtenerPermisosPorUsuarioCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class obtenerPermisosPorUsuarioCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal obtenerPermisosPorUsuarioCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    public delegate void listaEncuestasCompletedEventHandler(object sender, listaEncuestasCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class listaEncuestasCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal listaEncuestasCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    public delegate void listaEncuestas2CompletedEventHandler(object sender, listaEncuestas2CompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class listaEncuestas2CompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal listaEncuestas2CompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public encuesta[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((encuesta[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    public delegate void encuestaPorIdCompletedEventHandler(object sender, encuestaPorIdCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class encuestaPorIdCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal encuestaPorIdCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    public delegate void insertarEncuestaCompletedEventHandler(object sender, insertarEncuestaCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class insertarEncuestaCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal insertarEncuestaCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    public delegate void actualizarEncuestaCompletedEventHandler(object sender, actualizarEncuestaCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class actualizarEncuestaCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal actualizarEncuestaCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591